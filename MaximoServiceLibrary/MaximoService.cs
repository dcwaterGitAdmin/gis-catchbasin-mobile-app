using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using LocalDBLibrary;
using LocalDBLibrary.model;
using Newtonsoft.Json;
using RestSharp;
using MaximoServiceLibrary.model;
using MaximoServiceLibrary.repository;
using RestSharp.Serializers;
using System.IO;
using System.Net;

namespace MaximoServiceLibrary
{
    public class MaximoService
    {
        //public string BASE_HOST { get; set; } = "http://localhost:8080";
        //public string BASE_HOST = "https://bpl-max-test.dcwasa.com";
        public string BASE_HOST = "https://bpl-maxsch-dev.dcwasa.com";


        private string BASE_CONTEXT_PATH { get; set; } = "/maxrest/oslc";
        private string BASE_URL { get {return BASE_HOST + BASE_CONTEXT_PATH; } }

		private static readonly string _ltpatoken2_Cookie_Name = "LtpaToken2";
		private static readonly string _jsessionid_Cookie_Name = "JSESSIONID";



		private RestClient restClient;
		private string token;
		private string sessionId;

		public bool isOnline;

		// cons
		public MaximoService()
		{

			// todo : put app config

			restClient = new RestClient();
		}

		// helpers
		public RestRequest createRequest(string _url)
		{
			return createRequest(_url, false);
		}

		public RestRequest createRequest(string _url, bool isFullHrefUrl)
		{
			return createRequest(_url, isFullHrefUrl, Method.GET);
		}

		public RestRequest createRequest(string _url, bool isFullHrefUrl, Method method)
		{
			string finalUrl = _url;

			// fix the full href url to match BASE_URL
			if (isFullHrefUrl)
			{
				int contextPathIndex = _url.IndexOf(BASE_CONTEXT_PATH);
				string _baseHost = _url.Substring(0, contextPathIndex);

				if (!BASE_HOST.Equals(_baseHost))
				{
					finalUrl = BASE_HOST + _url.Substring(contextPathIndex);
				}
			}
			else
			{
				finalUrl = BASE_URL + _url;
			}

			var request = new RestRequest(finalUrl);
			request.Method = method;
			request.AddQueryParameter("lean", "1");
			request.AddCookie(_jsessionid_Cookie_Name, sessionId);
			request.AddCookie(_ltpatoken2_Cookie_Name, token);
            request.JsonSerializer = new RestSharpJsonNetSerializer();
            return request;
		}

		public bool checkIsOnline(string username, string password)
		{
			bool previousIsOnline = isOnline;

			var request = createRequest("/whoami");

			var response = restClient.Execute(request);

			this.isOnline = (response.ResponseStatus == ResponseStatus.Completed);

			if (isOnline)
			{
				//reconnect if the session is expired
				if (response.StatusCode == HttpStatusCode.BadRequest)
				{
					this.login(username, password);
				}
			}

			if (!previousIsOnline && isOnline)
			{
				this.login(username, password);
			}

			return this.isOnline;
		}

		public bool login(string username, string password)
		{

			string maxauth = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(username + ":" + password));
			var request = new RestRequest(BASE_URL + "/login");

			request.AddHeader("Authorization", "Basic " + maxauth);
			request.Method = Method.GET;
			request.AddHeader("Accept", "application/xml,text/xml,application/json");

			var response = restClient.Execute(request);

			if (response.ResponseStatus != ResponseStatus.Completed)
			{
				isOnline = false;
                //throw new Exception($"The application cannot access to Maximo {response.Content}");
                return false;
			}
			else
			{
				isOnline = true;
				foreach (RestResponseCookie cookie in response.Cookies.ToArray())
				{
					if (cookie.Name.ToUpper() == _ltpatoken2_Cookie_Name.ToUpper())
					{
						token = cookie.Value;
					}

					if (cookie.Name.ToUpper() == _jsessionid_Cookie_Name.ToUpper())
					{
						sessionId = cookie.Value;
					}
				}
				if (response.StatusCode == System.Net.HttpStatusCode.OK && sessionId != null && token != null)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}


		public MaximoUser whoami()
		{

			var request = createRequest("/whoami");

			var response = restClient.Execute(request);

			if (!response.IsSuccessful)
			{
				AppContext.Log.Warn("rest-service-error : " + response.StatusCode + " - [" + response.Content + "]");
				return null;
			}

			MaximoUser mxuserFromMaximo = JsonConvert.DeserializeObject<MaximoUser>(response.Content);



			return mxuserFromMaximo;
			

		}

		public void clearUserData()
		{
			token = null;
			sessionId = null;
		}

		public MaximoPersonGroup getPersonGroup(string personId)
		{
			var request = createRequest("/os/mxl_pergrp");
			request.AddQueryParameter("oslc.select", "*");
			request.AddQueryParameter("oslc.where", "persongroup=\"CB%\" and allpersongroupteam.resppartygroup=\"" + personId + "\"");


			var response = restClient.Execute(request);
			MaximoPersonGroupRestResponse maximoPersonGroupRestResponse = JsonConvert.DeserializeObject<MaximoPersonGroupRestResponse>(response.Content);
			if(maximoPersonGroupRestResponse.member != null && maximoPersonGroupRestResponse.member.Count > 0)
			{
				return maximoPersonGroupRestResponse.member[0];
			}
			else
			{
				return null;
			}
			
		}

		public List<MaximoPersonGroup> getPersonGroups()
		{
			var request = createRequest("/os/mxl_pergrp");
			request.AddQueryParameter("oslc.select", "*");
			request.AddQueryParameter("oslc.where", "persongroup=\"CB%\"");

			var response = restClient.Execute(request);

			if (!response.IsSuccessful)
			{
				AppContext.Log.Warn("rest-service-error : " + response.StatusCode + " - [" + response.Content + "]");
				return new List<MaximoPersonGroup>();
			}
			List<MaximoPersonGroup> personGroups = new List<MaximoPersonGroup>();

			MaximoPersonGroupPageableRestResponse mxPersonGroupPageableRestResponse =
				JsonConvert.DeserializeObject<MaximoPersonGroupPageableRestResponse>(response.Content);
			personGroups.AddRange(mxPersonGroupPageableRestResponse.member);

			// get next pages if there is any
			while (mxPersonGroupPageableRestResponse.responseInfo.nextPage != null)
			{
				request = createRequest(mxPersonGroupPageableRestResponse.responseInfo.nextPage.href, true);

				response = restClient.Execute(request);

				if (!response.IsSuccessful)
				{
					AppContext.Log.Warn("rest-service-error : " + response.StatusCode + " - [" + response.Content + "]");
					// todo - throw exception here?
					return personGroups;
				}

				mxPersonGroupPageableRestResponse =
					JsonConvert.DeserializeObject<MaximoPersonGroupPageableRestResponse>(response.Content);
				personGroups.AddRange(mxPersonGroupPageableRestResponse.member);
			}

			return personGroups;


		}

		// methods

		public List<MaximoWorkOrder> getWorkOrders(string persongroup)
		{

			string where = "failurecode=\"CATCHBASIN\"" +
						   " and siteid=\"DWS_DSS\"" +
						   " and service=\"DSS\"" +
						   " and historyflag=0" +
						   " and status=\"DISPTCHD\"" +
						   " and worktype in [\"INV\",\"EMERG\",\"PM\",\"INSP\"]" +
						   $" and persongroup in [\"{persongroup}\",\"CB00\"]"+
						   " and schedstart<=\"" + System.DateTime.UtcNow.ToString("yyyy-MM-dd'T'HH:mm:ss") + "\"";

			string selectFields =
                "href,"+
				"description_longdescription," +
				"schedstart,woclass," +
				"workorderid," +
				"statusdate," +
				"parent," +
				"classstructureid," +
				"changeby," +
				"assetnum," +
				"actlabcost," +
				"reportedby," +
				"woeq10," +
				"description," +
				"persongroup," +
				"np_statusmemo," +
				"origproblemtype," +
				"origrecordid," +
				"service," +
				"wolo4," +
				"wonum," +
				"wolo2," +
				"orgid," +
				"wo1," +
				"siteid," +
				"worktype," +
				"origrecordclass," +
				"remarkdesc," +
				"newchildclass," +
				"location," +
				"status," +
				"problemcode," +
				"failurecode," +
				"receivedvia," +
				"workorderspec," +
				"failurereport," +
                "labtrans," +
                "tooltrans," +
                "failureremark," +
                "locations";

            //selectFields = "*";
			var request = createRequest("/os/dcw_cb_wo");
			request.AddQueryParameter("oslc.where", where);
			request.AddQueryParameter("oslc.select", selectFields);
			request.AddQueryParameter("oslc.pageSize", "3");
			request.AddQueryParameter("pageno", "1");

			var response = restClient.Execute(request);

			if (!response.IsSuccessful)
			{
				AppContext.Log.Warn("rest-service-error : " + response.StatusCode + " - [" + response.Content + "]");
				throw new Exception("rest-service-error fetch work orders: " + response.StatusCode + " - [" + response.Content + "]");
            }

			List<MaximoWorkOrder> maximoWorkOrderList = new List<MaximoWorkOrder>();

			MaximoWorkOrderPageableRestResponse mxwoPageableRestResponse =
				JsonConvert.DeserializeObject<MaximoWorkOrderPageableRestResponse>(response.Content);
			maximoWorkOrderList.AddRange(mxwoPageableRestResponse.member);

			// get next pages if there is any
			while (mxwoPageableRestResponse.responseInfo.nextPage != null)
			{
				request = createRequest(mxwoPageableRestResponse.responseInfo.nextPage.href, true);

				response = restClient.Execute(request);

				if (!response.IsSuccessful)
				{
					AppContext.Log.Warn("rest-service-error : " + response.StatusCode + " - [" + response.Content + "]");
                    throw new Exception("rest-service-error fetch work orders: " + response.StatusCode + " - [" + response.Content + "]");
                }

                mxwoPageableRestResponse =
					JsonConvert.DeserializeObject<MaximoWorkOrderPageableRestResponse>(response.Content);
				maximoWorkOrderList.AddRange(mxwoPageableRestResponse.member);
			}

			return maximoWorkOrderList;
		}
		
		public MaximoWorkOrder getWorkOrderByHref(String workOrderHref)
		{
			var request = createRequest(workOrderHref, true);
			var response = restClient.Execute(request);

			if (!response.IsSuccessful)
			{
				AppContext.Log.Warn("rest-service-error : " + response.StatusCode + " - [" + response.Content + "]");
				throw new Exception("rest-service-error : " + response.StatusCode + " - [" + response.Content + "]");
			}
			
			MaximoWorkOrder maximoWorkOrder = JsonConvert.DeserializeObject<MaximoWorkOrder>(response.Content);
			return maximoWorkOrder;
		}

		public MaximoWorkOrder getWorkOrderByWorkorderid(long workorderid)
		{
			var request = createRequest("/os/dcw_cb_wo/" + workorderid, false);
			var response = restClient.Execute(request);

			if (!response.IsSuccessful)
			{
				AppContext.Log.Warn("rest-service-error : " + response.StatusCode + " - [" + response.Content + "]");
				throw new Exception("rest-service-error : " + response.StatusCode + " - [" + response.Content + "]");
			}
			
			MaximoWorkOrder maximoWorkOrder = JsonConvert.DeserializeObject<MaximoWorkOrder>(response.Content);
			return maximoWorkOrder;
		}
		
		public MaximoWorkOrder updateWorkOrder(MaximoWorkOrder maximoWorkOrder)
		{
            AppContext.Log.Info($"[MX] update work order : [{maximoWorkOrder.wonum}] - [{maximoWorkOrder.workorderid}]");

            var request = createRequest("/os/dcw_cb_wo/" + maximoWorkOrder.workorderid, false, Method.POST);
			request.AddHeader("x-method-override", "PATCH");

			// create an empty workorder
			MaximoWorkOrderForUpdate workOrderToBePosted = new MaximoWorkOrderForUpdate();
			workOrderToBePosted.remarkdesc = maximoWorkOrder.remarkdesc;
			workOrderToBePosted.workorderspec = maximoWorkOrder.workorderspec;
            workOrderToBePosted.failurereport = maximoWorkOrder.failurereport;
            //workOrderToBePosted.doclinks = maximoWorkOrder.doclink;
            workOrderToBePosted.assetnum = maximoWorkOrder.assetnum;
            workOrderToBePosted.statusdate = maximoWorkOrder.statusdate;
            
            // In order to not get error from maximo side in case of failed synchronization
            if (workOrderToBePosted.workorderspec != null)
            {
	            workOrderToBePosted.workorderspec.ForEach(child => child._rowstamp = null);
            }
            if (workOrderToBePosted.failurereport != null)
            {
	            workOrderToBePosted.failurereport.ForEach(child => child._rowstamp = null);
            }

            request.AddJsonBody(workOrderToBePosted);

			var response = restClient.Execute(request);
			

			if (!response.IsSuccessful)
			{
                AppContext.Log.Error($"[MX] - update work order Error url : {response.ResponseUri.ToString()}");
                AppContext.Log.Error($"[MX] - update work order Error request body : {request.JsonSerializer.Serialize(workOrderToBePosted)}");
                AppContext.Log.Error($"[MX] - update work order operation response : [{response.StatusCode}] - [{response.Content}]");

                throw new Exception("update-work-order-error : " + response.StatusCode + " - [" + response.Content + "]");
			}

            AppContext.Log.Info($"[MX] successfully updated work order : [{maximoWorkOrder.wonum}] - [{maximoWorkOrder.workorderid}]");
            MaximoWorkOrder freshWorkOrder = null;
            if (maximoWorkOrder.href != null)
            {
	            freshWorkOrder = getWorkOrderByHref(maximoWorkOrder.href);
            }
            else if (maximoWorkOrder.workorderid != null && maximoWorkOrder.workorderid != 0)
            {
	            freshWorkOrder = getWorkOrderByWorkorderid(maximoWorkOrder.workorderid);
            }
            return freshWorkOrder;
		}

	    public MaximoWorkOrder updateWorkOrderStatus(MaximoWorkOrder maximoWorkOrder)
		{
            AppContext.Log.Info($"[MX] update work order status : [{maximoWorkOrder.wonum}] - [{maximoWorkOrder.workorderid}]");

            var request = createRequest("/os/dcw_cb_wo/" + maximoWorkOrder.workorderid, false, Method.POST);
			request.AddHeader("x-method-override", "PATCH");

			// create an empty workorder
			MaximoWorkOrderForStatusUpdate workOrderToBePosted = new MaximoWorkOrderForStatusUpdate();
			workOrderToBePosted.status = maximoWorkOrder.status;
			workOrderToBePosted.np_statusmemo = maximoWorkOrder.np_statusmemo;
            
            request.AddJsonBody(workOrderToBePosted);

			var response = restClient.Execute(request);
			
			if (!response.IsSuccessful)
			{
                AppContext.Log.Error($"[MX] - update work order status Error url : {response.ResponseUri.ToString()}");
                AppContext.Log.Error($"[MX] - update work order status Error request body : {request.JsonSerializer.Serialize(workOrderToBePosted)}");
                AppContext.Log.Error($"[MX] - update work order status operation response : [{response.StatusCode}] - [{response.Content}]");

                throw new Exception("update-work-order-status-error : " + response.StatusCode + " - [" + response.Content + "]");
			}

            AppContext.Log.Info($"[MX] successfully updated work order status : [{maximoWorkOrder.wonum}] - [{maximoWorkOrder.workorderid}]");
            MaximoWorkOrder freshWorkOrder = null;
            if (maximoWorkOrder.href != null)
            {
	            freshWorkOrder = getWorkOrderByHref(maximoWorkOrder.href);
            }
            else if (maximoWorkOrder.workorderid != null && maximoWorkOrder.workorderid != 0)
            {
	            freshWorkOrder = getWorkOrderByWorkorderid(maximoWorkOrder.workorderid);
            }
            return freshWorkOrder;
		}
	    
	    public MaximoWorkOrder updateWorkOrderProblemCode(MaximoWorkOrder maximoWorkOrder)
	    {
		    AppContext.Log.Info($"[MX] update work order status : [{maximoWorkOrder.wonum}] - [{maximoWorkOrder.workorderid}]");

		    var request = createRequest("/os/dcw_cb_wo/" + maximoWorkOrder.workorderid, false, Method.POST);
		    request.AddHeader("x-method-override", "PATCH");

		    // create an empty workorder
		    MaximoWorkOrderForProblemCodeUpdate workOrderToBePosted = new MaximoWorkOrderForProblemCodeUpdate();
		    workOrderToBePosted.problemcode = maximoWorkOrder.problemcode;
			workOrderToBePosted.classstructureid = "1356";

			request.AddJsonBody(workOrderToBePosted);

		    var response = restClient.Execute(request);
			
		    if (!response.IsSuccessful)
		    {
			    AppContext.Log.Error($"[MX] - update work order problemcode Error url : {response.ResponseUri.ToString()}");
			    AppContext.Log.Error($"[MX] - update work order problemcode Error request body : {request.JsonSerializer.Serialize(workOrderToBePosted)}");
			    AppContext.Log.Error($"[MX] - update work order problemcode operation response : [{response.StatusCode}] - [{response.Content}]");

			    throw new Exception("update-work-order-problemcode-error : " + response.StatusCode + " - [" + response.Content + "]");
		    }

		    AppContext.Log.Info($"[MX] successfully updated work order problemcode : [{maximoWorkOrder.wonum}] - [{maximoWorkOrder.workorderid}]");
		    MaximoWorkOrder freshWorkOrder = null;
		    if (maximoWorkOrder.href != null)
		    {
			    freshWorkOrder = getWorkOrderByHref(maximoWorkOrder.href);
		    }
		    else if (maximoWorkOrder.workorderid != null && maximoWorkOrder.workorderid != 0)
		    {
			    freshWorkOrder = getWorkOrderByWorkorderid(maximoWorkOrder.workorderid);
		    }
		    return freshWorkOrder;
	    }

	    
		public MaximoWorkOrder createWorkOrder(MaximoWorkOrder maximoWorkOrder)
		{
            AppContext.Log.Info($"[MX] create work order : [{maximoWorkOrder.Id}] - [{maximoWorkOrder.workorderid}]");

            var request = createRequest("/os/dcw_cb_wo", false, Method.POST);
			request.AddHeader("x-method-override", "POST");
			
			
			request.AddJsonBody(maximoWorkOrder);

			var response = restClient.Execute(request);
			

			if (!response.IsSuccessful)
			{
                AppContext.Log.Error($"[MX] - create work order Error url : {response.ResponseUri.ToString()}");
                AppContext.Log.Error($"[MX] - create work order Error request body : {request.JsonSerializer.Serialize(maximoWorkOrder)}");
                AppContext.Log.Error($"[MX] - create work order operation response : [{response.StatusCode}] - [{response.Content}]");

                throw new Exception("create-work-order-error : " + response.StatusCode + " - [" + response.Content + "]");
			}

			string workOrderHref = null;
			
			foreach (var responseHeader in response.Headers)
			{
				if (responseHeader.Name.Equals("Location"))
				{
					workOrderHref = responseHeader.Value.ToString();
				}
			}
            AppContext.Log.Info($"[MX] successfully created work order : [{workOrderHref}]");

            return getWorkOrderByHref(workOrderHref);
		}

		public MaximoWorkOrder updateWorkOrderActuals(MaximoWorkOrder maximoWorkOrder)
		{
            AppContext.Log.Info($"[MX] update work order actuals : [{maximoWorkOrder.wonum}] - [{maximoWorkOrder.workorderid}]");

            var request = createRequest("/os/dcw_cb_wo/" + maximoWorkOrder.workorderid, false, Method.POST);
			request.AddHeader("x-method-override", "PATCH");
			
			// create an empty workorder
			MaximoWorkOrderLabtransForUpdate workOrderToBePosted = new MaximoWorkOrderLabtransForUpdate();

			workOrderToBePosted.labtrans = maximoWorkOrder.labtrans;
            workOrderToBePosted.tooltrans = maximoWorkOrder.tooltrans;
            
            // In order to not get error from maximo side in case of failed synchronization
            if (workOrderToBePosted.labtrans != null)
            {
	            workOrderToBePosted.labtrans.ForEach(child => child._rowstamp = null);
            }
            if (workOrderToBePosted.tooltrans != null)
            {
	            workOrderToBePosted.tooltrans.ForEach(child => child._rowstamp = null);
            }
            
            request.JsonSerializer = new RestSharpJsonNetSerializer();
			request.AddJsonBody(workOrderToBePosted);

			var response = restClient.Execute(request);
			
			if (!response.IsSuccessful)
			{
                AppContext.Log.Error($"[MX] - update work order actuals Error url : {response.ResponseUri.ToString()}");
                AppContext.Log.Error($"[MX] - update work order actuals Error request body : {request.JsonSerializer.Serialize(workOrderToBePosted)}");
                AppContext.Log.Error($"[MX] - update work order actuals operation response : [{response.StatusCode}] - [{response.Content}]");

                throw new Exception("update-work-order-error : " + response.StatusCode + " - [" + response.Content + "]");

			}
            AppContext.Log.Info($"[MX] successfully updated work order actuals : [{maximoWorkOrder.wonum}] - [{maximoWorkOrder.workorderid}]");

            MaximoWorkOrder freshWorkOrder = null;
            if (maximoWorkOrder.href != null)
            {
                freshWorkOrder = getWorkOrderByHref(maximoWorkOrder.href);
            }
            else if (maximoWorkOrder.workorderid != null && maximoWorkOrder.workorderid != 0)
            {
                freshWorkOrder = getWorkOrderByWorkorderid(maximoWorkOrder.workorderid);
            }
            return freshWorkOrder;
        }

		public MaximoDocLinks createAttachment(MaximoWorkOrder maximoWorkOrder, MaximoDocLinks doc)
		{
			AppContext.Log.Info($"[MX] create attachment : [{maximoWorkOrder.wonum}] - [{maximoWorkOrder.workorderid}]");

			var request = createRequest("/os/dcw_cb_wo/" + maximoWorkOrder.workorderid + "/doclinks", false, Method.POST);
			request.AddHeader("x-document-meta", "Attachments");
			request.AddHeader("slug", doc.fileName);
			request.AddHeader("x-document-description", doc.description);
			request.AddHeader("custom-encoding", "base64");

			request.AddParameter("text/plain", doc.documentdata, ParameterType.RequestBody);

			var response = restClient.Execute(request);

			if (!response.IsSuccessful)
			{
				AppContext.Log.Error($"[MX] - create attachment Error url : {response.ResponseUri.ToString()}");
				AppContext.Log.Error($"[MX] - create attachment Error request body : {request.Parameters.FirstOrDefault(p => p.Type == ParameterType.RequestBody)}");
				AppContext.Log.Error($"[MX] - create attachment  operation response : [{response.StatusCode}] - [{response.Content}]");

				throw new Exception("create-attachment-error : " + response.StatusCode + " - [" + response.Content + "]");
			}

			AppContext.Log.Info($"[MX] successfully create attachment  : [{maximoWorkOrder.wonum}] - [{maximoWorkOrder.workorderid}]");
			string doclinkHref = null;

			foreach (var responseHeader in response.Headers)
			{
				if (responseHeader.Name.Equals("Location"))
				{
					doclinkHref = responseHeader.Value.ToString();
				}
			}

			return GetMaximoDocLinks(maximoWorkOrder, doclinkHref);
		}

		public MaximoDocLinks GetMaximoDocLinks(MaximoWorkOrder maximoWorkOrder, string doclinkHref)
		{

			char[] spearator = { '/' };
			var list = doclinkHref.Split(spearator);
			var identifier = list.Last();

			var request = createRequest("/os/dcw_cb_wo/" + maximoWorkOrder.workorderid + "/doclinks/meta/" + identifier, false);

			var response = restClient.Execute(request);

			if (!response.IsSuccessful)
			{
				AppContext.Log.Warn("rest-service-error : " + response.StatusCode + " - [" + response.Content + "]");
				throw new Exception("rest-service-error : " + response.StatusCode + " - [" + response.Content + "]");
			}

			MaximoDocLinks maximoDocLinksRestResponse = JsonConvert.DeserializeObject<MaximoDocLinks>(response.Content);
			maximoDocLinksRestResponse.path = DownloadAttachment(maximoDocLinksRestResponse, doclinkHref);

			return maximoDocLinksRestResponse;
		}

		public string DownloadAttachment(MaximoDocLinks maximoDocLinks, string url)
		{
			System.IO.Directory.CreateDirectory("C:\\CatchBasin\\attachments");
			string path = $"C:\\CatchBasin\\attachments\\{maximoDocLinks.docinfoid}_{maximoDocLinks.fileName}";
			if (!File.Exists(path))
			{
				try
				{
					using (var client = new WebClient())
					{

						client.Headers.Add(HttpRequestHeader.Cookie, $"{_jsessionid_Cookie_Name}=sessionId; {_ltpatoken2_Cookie_Name}={token};");
						client.DownloadFileAsync(new Uri(url), path);
					}
				}
				catch (Exception e)
				{
					AppContext.Log.Warn($"download-attachment-error : {e.ToString()}");
				}
			}
			return path;
		}


		public List<MaximoDocLinks> getWorkOrderDocLinks(MaximoWorkOrder wo)
		{
			var request = createRequest("/os/dcw_cb_wo/" + wo.workorderid + "/doclinks", false);
			var response = restClient.Execute(request);

			if (!response.IsSuccessful)
			{
				AppContext.Log.Warn("rest-service-error : " + response.StatusCode + " - [" + response.Content + "]");
				throw new Exception("rest-service-error : " + response.StatusCode + " - [" + response.Content + "]");
			}
			
			MaximoDocLinksRestResponse maximoDocLinksRestResponse = JsonConvert.DeserializeObject<MaximoDocLinksRestResponse>(response.Content);
			if (maximoDocLinksRestResponse.member == null)
			{
				return new List<MaximoDocLinks>();
			}
			else
			{
				List<MaximoDocLinks> result = new List<MaximoDocLinks>();
				foreach (var maximoDocLinksWrapper in maximoDocLinksRestResponse.member)
				{
					maximoDocLinksWrapper.describedBy.path = DownloadAttachment(maximoDocLinksWrapper.describedBy, maximoDocLinksWrapper.href);
					result.Add(maximoDocLinksWrapper.describedBy);
				}
				
				return result;
			}
		}
		
		public List<FailureList> getFailureList(string parentIds)
		{
			var request = createRequest("/os/dcw_kona_failurelist");
			request.AddQueryParameter("oslc.select", "*");
			request.AddQueryParameter("oslc.pageSize", "10");
			request.AddQueryParameter("oslc.where", $"parent in [{parentIds}]");
			var response = restClient.Execute(request);

			if (!response.IsSuccessful)
			{
				AppContext.Log.Warn("rest-service-error : " + response.StatusCode + " - [" + response.Content + "]");
				return new List<FailureList>();
			}

			List<FailureList> FailureLists = new List<FailureList>();

			FailureListPageableRestResponse flPageableRestResponse =
				JsonConvert.DeserializeObject<FailureListPageableRestResponse>(response.Content);
			FailureLists.AddRange(flPageableRestResponse.member);

			// get next pages if there is any
			while (flPageableRestResponse.responseInfo.nextPage != null)
			{
				request = createRequest(flPageableRestResponse.responseInfo.nextPage.href, true);

				response = restClient.Execute(request);

				if (!response.IsSuccessful)
				{
					AppContext.Log.Warn("rest-service-error : " + response.StatusCode + " - [" + response.Content + "]");
					// todo - throw exception here?
					return FailureLists;
				}

				flPageableRestResponse =
					JsonConvert.DeserializeObject<FailureListPageableRestResponse>(response.Content);
				FailureLists.AddRange(flPageableRestResponse.member);
			}

			return FailureLists;

		}

		public MaximoAsset createAsset(MaximoAsset maximoAsset)
		{
			AppContext.Log.Info($"[MX] create asset : [{maximoAsset.assettag}] - [{maximoAsset.Id}]");
			
            var request = createRequest("/os/dcw_cbasset", false, Method.POST);
			request.AddHeader("x-method-override", "POST");
			
			MaximoAssetForCreation maximoAssetForCreation = new MaximoAssetForCreation();
			maximoAssetForCreation.assettag = maximoAsset.assettag;
			maximoAssetForCreation.eq3 = maximoAsset.eq3;
			maximoAssetForCreation.classstructureid = maximoAsset.classstructureid;
			maximoAssetForCreation.siteid = maximoAsset.siteid;

            maximoAssetForCreation.status = maximoAsset.status;
            maximoAssetForCreation.description = maximoAsset.description;
            maximoAssetForCreation.failurecode = maximoAsset.failurecode;
            maximoAssetForCreation.orgid = maximoAsset.orgid;
            maximoAssetForCreation.plussfeatureclass = maximoAsset.plussfeatureclass;
            maximoAssetForCreation.plussisgis = maximoAsset.plussisgis;


            if (maximoAssetForCreation.siteid == null)
            {
                maximoAssetForCreation.siteid = "DWS_DSS";
            }

			request.AddJsonBody(maximoAssetForCreation);

			var response = restClient.Execute(request);
			
			if (!response.IsSuccessful)
			{
                AppContext.Log.Error($"[MX] - create asset Error url : {response.ResponseUri.ToString()}");
                AppContext.Log.Error($"[MX] - create asset Error request body : {request.JsonSerializer.Serialize(maximoAssetForCreation)}");
                AppContext.Log.Error($"[MX] - create asset operation response : [{response.StatusCode}] - [{response.Content}]");

                throw new Exception("create-asset-error : " + response.StatusCode + " - [" + response.Content + "]");
			}

			string assetHref = null;
			
			foreach (var responseHeader in response.Headers)
			{
				if (responseHeader.Name.Equals("Location"))
				{
					assetHref = responseHeader.Value.ToString();
				}
			}

            AppContext.Log.Info($"[MX] successfully created asset : [{assetHref}]");

            return getAssetByHref(assetHref);
		}
		
		
		public MaximoAsset updateAsset(MaximoAsset maximoAsset)
		{
            AppContext.Log.Info($"[MX] update asset : [{maximoAsset.assetnum}] - [{maximoAsset.href}]");

            var request = createRequest(maximoAsset.href, true, Method.POST);
			request.AddHeader("x-method-override", "PATCH");

			request.AddJsonBody(maximoAsset);

			var response = restClient.Execute(request);

			if (!response.IsSuccessful)
			{
                AppContext.Log.Error($"[MX] - update asset Error url : {response.ResponseUri.ToString()}");
                AppContext.Log.Error($"[MX] - update asset Error request body : {request.JsonSerializer.Serialize(maximoAsset)}");
                AppContext.Log.Error($"[MX] - update asset operation response : [{response.StatusCode}] - [{response.Content}]");

                throw new Exception("update-asset-error : " + response.StatusCode + " - [" + response.Content + "]");
			}

            AppContext.Log.Info($"[MX] successfully updated asset : [{maximoAsset.assetnum}] - [{maximoAsset.href}]");
            return getAssetByHref(maximoAsset.href);
		}

		public List<MaximoAttribute> getAttributes()
		{
			var request = createRequest("/os/mxl_assetattribute");
			request.AddQueryParameter("oslc.select", "*");
			request.AddQueryParameter("oslc.pageSize", "10");
			request.AddQueryParameter("pageno", "1");
			var response = restClient.Execute(request);
			if (!response.IsSuccessful)
			{
				AppContext.Log.Warn("rest-service-error : " + response.StatusCode + " - [" + response.Content + "]");
				return new List<MaximoAttribute>();
			}
			List<MaximoAttribute> maximoAttributes = new List<MaximoAttribute>();

			MaximoAttributePageableRestResponse mxl_assetattributePageableRestResponse =
				JsonConvert.DeserializeObject<MaximoAttributePageableRestResponse>(response.Content);
			maximoAttributes.AddRange(mxl_assetattributePageableRestResponse.member);

			// get next pages if there is any
			while (mxl_assetattributePageableRestResponse.responseInfo.nextPage != null)
			{
				request = createRequest(mxl_assetattributePageableRestResponse.responseInfo.nextPage.href, true);

				response = restClient.Execute(request);

				if (!response.IsSuccessful)
				{
					AppContext.Log.Warn("rest-service-error : " + response.StatusCode + " - [" + response.Content + "]");
					// todo - throw exception here?
					return maximoAttributes;
				}

				mxl_assetattributePageableRestResponse =
					JsonConvert.DeserializeObject<MaximoAttributePageableRestResponse>(response.Content);
				maximoAttributes.AddRange(mxl_assetattributePageableRestResponse.member);
			}

			return maximoAttributes;

		}

		public List<MaximoInventory> getInventory()
		{
			var request = createRequest("/os/mxinventory");
			request.AddQueryParameter("oslc.select", "itemnum,location,binnum");
			request.AddQueryParameter("oslc.pageSize", "10");
			request.AddQueryParameter("pageno", "1");
			request.AddQueryParameter("oslc.where", "location=\"OSTFLEET\" and binnum=\"CBTRUCKS\"");
			var response = restClient.Execute(request);

			if (!response.IsSuccessful)
			{
				AppContext.Log.Warn("rest-service-error : " + response.StatusCode + " - [" + response.Content + "]");
				return new List<MaximoInventory>();
			}
			List<MaximoInventory> tools = new List<MaximoInventory>();

			MaximoInventoryPageableRestResponse mxinventoryPageableRestResponse =
				JsonConvert.DeserializeObject<MaximoInventoryPageableRestResponse>(response.Content);
			tools.AddRange(mxinventoryPageableRestResponse.member);

			// get next pages if there is any
			while (mxinventoryPageableRestResponse.responseInfo.nextPage != null)
			{
				request = createRequest(mxinventoryPageableRestResponse.responseInfo.nextPage.href, true);

				response = restClient.Execute(request);

				if (!response.IsSuccessful)
				{
					AppContext.Log.Warn("rest-service-error : " + response.StatusCode + " - [" + response.Content + "]");
					// todo - throw exception here?
					return tools;
				}

				mxinventoryPageableRestResponse =
					JsonConvert.DeserializeObject<MaximoInventoryPageableRestResponse>(response.Content);
				tools.AddRange(mxinventoryPageableRestResponse.member);
			}

			return tools;
		}

		public List<MaximoDomain> getDomains()
		{
			var request = createRequest("/os/mxdomain");
			request.AddQueryParameter("oslc.select", "synonymdomain,domainid,alndomain,description,numericdomain");
			request.AddQueryParameter("oslc.pageSize", "10");
			request.AddQueryParameter("pageno", "1");

			var response = restClient.Execute(request);

			if (!response.IsSuccessful)
			{
				AppContext.Log.Warn("rest-service-error : " + response.StatusCode + " - [" + response.Content + "]");
				return new List<MaximoDomain>();
			}
			List<MaximoDomain> maximoDomains = new List<MaximoDomain>();

			MaximoDomainPageableRestResponse mxdomainPageableRestResponse =
				JsonConvert.DeserializeObject<MaximoDomainPageableRestResponse>(response.Content);
			maximoDomains.AddRange(mxdomainPageableRestResponse.member);

			// get next pages if there is any
			while (mxdomainPageableRestResponse.responseInfo.nextPage != null)
			{
				request = createRequest(mxdomainPageableRestResponse.responseInfo.nextPage.href, true);

				response = restClient.Execute(request);

				if (!response.IsSuccessful)
				{
					AppContext.Log.Warn("rest-service-error : " + response.StatusCode + " - [" + response.Content + "]");
					// todo - throw exception here?
					return maximoDomains;
				}

				mxdomainPageableRestResponse =
					JsonConvert.DeserializeObject<MaximoDomainPageableRestResponse>(response.Content);
				maximoDomains.AddRange(mxdomainPageableRestResponse.member);
			}

			return maximoDomains;

		}
		
		public MaximoAsset getAssetByHref(String assetHref)
		{
			var request = createRequest(assetHref, true);
			var response = restClient.Execute(request);

			if (!response.IsSuccessful)
			{
				AppContext.Log.Warn("rest-service-error : " + response.StatusCode + " - [" + response.Content + "]");
				throw new Exception("rest-service-error : " + response.StatusCode + " - [" + response.Content + "]");
			}
			
			MaximoAsset maximoAsset = JsonConvert.DeserializeObject<MaximoAsset>(response.Content);
			return maximoAsset;
		}

		public MaximoAsset getAssetByAssetnum(String assetnum)
		{
            if (String.IsNullOrEmpty(assetnum)) { return null; }
			var request = createRequest("/os/dcw_cbasset", false);
			request.AddParameter("oslc.where", $"assetnum=\"{assetnum}\"");
			request.AddParameter("oslc.select", "*");
			request.AddParameter("oslc.pageSize", "1");
			
			var response = restClient.Execute(request);

			if (!response.IsSuccessful)
			{
				throw new Exception("getAssetByAssetnum-service-error : " + response.StatusCode + " - [" + response.Content + "]");
			}
			
			MaximoAssetRestResponse maximoAssetRestResponse = JsonConvert.DeserializeObject<MaximoAssetRestResponse>(response.Content);

			if (maximoAssetRestResponse.member.Count == 0)
				return null;

			MaximoAsset maximoAsset = maximoAssetRestResponse.member[0];
			return maximoAsset;
		}
		

		public List<MaximoLabor> getLabors(string laborcraft)
		{
			var request = createRequest("/os/mxlabor");
			request.AddQueryParameter("oslc.select", "*");
			request.AddQueryParameter("oslc.pageSize", "10");
			request.AddQueryParameter("oslc.where",$"laborcraftrate.craft=\"{laborcraft}\"");
			request.AddQueryParameter("pageno", "1");

			var response = restClient.Execute(request);

			if (!response.IsSuccessful)
			{
				AppContext.Log.Warn("rest-service-error : " + response.StatusCode + " - [" + response.Content + "]");
				return new List<MaximoLabor>();
			}
			List<MaximoLabor> maximoLabors = new List<MaximoLabor>();

			MaximoLaborPageableRestResponse mxlaborPageableRestResponse =
				JsonConvert.DeserializeObject<MaximoLaborPageableRestResponse>(response.Content);
			maximoLabors.AddRange(mxlaborPageableRestResponse.member);

			// get next pages if there is any
			while (mxlaborPageableRestResponse.responseInfo.nextPage != null)
			{
				request = createRequest(mxlaborPageableRestResponse.responseInfo.nextPage.href, true);

				response = restClient.Execute(request);

				if (!response.IsSuccessful)
				{
					AppContext.Log.Warn("rest-service-error : " + response.StatusCode + " - [" + response.Content + "]");
					// todo - throw exception here?
					return maximoLabors;
				}

				mxlaborPageableRestResponse =
					JsonConvert.DeserializeObject<MaximoLaborPageableRestResponse>(response.Content);
				maximoLabors.AddRange(mxlaborPageableRestResponse.member);
			}

			return maximoLabors;
		}


	}

	public class RestSharpJsonNetSerializer : ISerializer
	{
		private readonly Newtonsoft.Json.JsonSerializer _serializer;

		/// <summary>
		/// Default serializer
		/// </summary>
		public RestSharpJsonNetSerializer()
		{
			ContentType = "application/json";
			_serializer = new Newtonsoft.Json.JsonSerializer
			{
				MissingMemberHandling = MissingMemberHandling.Ignore,
				NullValueHandling = NullValueHandling.Ignore,
				DefaultValueHandling = DefaultValueHandling.Include
			};
		}

		/// <summary>
		/// Default serializer with overload for allowing custom Json.NET settings
		/// </summary>
		public RestSharpJsonNetSerializer(Newtonsoft.Json.JsonSerializer serializer)
		{
			ContentType = "application/json";
			_serializer = serializer;
		}

		/// <summary>
		/// Serialize the object as JSON
		/// </summary>
		/// <param name="obj">Object to serialize
		/// <returns>JSON as String</returns>
		public string Serialize(object obj)
		{
			using (var stringWriter = new StringWriter())
			{
				using (var jsonTextWriter = new JsonTextWriter(stringWriter))
				{
					jsonTextWriter.Formatting = Formatting.Indented;
					jsonTextWriter.QuoteChar = '"';

					_serializer.Serialize(jsonTextWriter, obj);

					var result = stringWriter.ToString();
					return result;
				}
			}
		}

		/// <summary>
		/// Unused for JSON Serialization
		/// </summary>
		public string DateFormat { get; set; }
		/// <summary>
		/// Unused for JSON Serialization
		/// </summary>
		public string RootElement { get; set; }
		/// <summary>
		/// Unused for JSON Serialization
		/// </summary>
		public string Namespace { get; set; }
		/// <summary>
		/// Content type for serialized content
		/// </summary>
		public string ContentType { get; set; }
	}
}