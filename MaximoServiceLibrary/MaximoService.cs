using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LocalDBLibrary;
using Newtonsoft.Json;
using RestSharp;
using MaximoServiceLibrary.model;
using MaximoServiceLibrary.repository;

namespace MaximoServiceLibrary
{
	public class MaximoService
	{
		private static readonly string BASE_HOST = "http://localhost:8080";
		//private static readonly string BASE_HOST = "https://bpl-max-test.dcwasa.com";

		private static readonly string BASE_CONTEXT_PATH = "/maxrest/oslc";
		private static readonly string BASE_URL = BASE_HOST + BASE_CONTEXT_PATH;

		private static readonly string _ltpatoken2_Cookie_Name = "LtpaToken2";
		private static readonly string _jsessionid_Cookie_Name = "JSESSIONID";

		// private 
		private DbConnection dbConnection;
		private UserRepository userRepository;
		
		private RestClient restClient;
		private string token;
		private string sessionId;

		private string username;
		private string password;

		// public
		public MaximoUser mxuser;
		public LoginDelegateHandler loginDelegate;
		public LogoutDelegateHandler logoutDelegate;
		public bool isUserLoggedIn = false;
		public bool isOnline; 


		// delegate
		public delegate void LoginDelegateHandler();

		public delegate void LogoutDelegateHandler();

		// cons
		public MaximoService(DbConnection _dbConnection,
			UserRepository _userRepository)
		{
			this.dbConnection = _dbConnection;
			this.userRepository = _userRepository;
			
			// todo : put app config
			
			restClient = new RestClient();
			loginDelegate = new LoginDelegateHandler(whoami);
			//  loginDelegate += getWorkOrders;
			logoutDelegate = new LogoutDelegateHandler(clearUserData);
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

			return request;
		}

		public bool login(string username, string password)
		{
			this.username = username;
			this.password = password;
			
			isUserLoggedIn = false;
			
			string maxauth = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(username + ":" + password));
			var request = new RestRequest(BASE_URL + "/login");

			request.AddHeader("Authorization", "Basic " + maxauth);
			request.Method = Method.GET;
			request.AddHeader("Accept", "application/xml,text/xml,application/json");

			var response = restClient.Execute(request);

			if (response.ResponseStatus != ResponseStatus.Completed)
			{
				isOnline = false;
			}
			else
			{
				isOnline = true;
			}

			if (isOnline)
			{
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
					isUserLoggedIn = true;
					loginDelegate();
					return true;
				}
				else
				{
					return false;
				}
			}
			else 
			{
               
				MaximoUser maximoUser = userRepository.findOne(username);
				if (maximoUser.password.Equals(password))
				{
					mxuser = maximoUser;
					
					isUserLoggedIn = true;
					loginDelegate();
					return true;
				}
				else
				{
					return false;
				}
			}
		}

		public void logout()
		{
			loginDelegate();
		}

		public void whoami()
		{
			if (isOnline)
			{
				var request = createRequest("/whoami");

				var response = restClient.Execute(request);

				mxuser = JsonConvert.DeserializeObject<MaximoUser>(response.Content);

				MaximoUser maximoUserFromDb = userRepository.findOne(mxuser.userName);
				if (maximoUserFromDb != null)
				{
					mxuser.Id = maximoUserFromDb.Id;
				}

				mxuser.password = this.password;

				userRepository.upsert(mxuser);
			}
		}

		public void clearUserData()
		{
			isUserLoggedIn = false;
			mxuser = null;
			token = null;
			sessionId = null;
		}

		public string findPersonGroup()
		{
			var persongrops = "\"CB00\"";

			var request = createRequest("/os/mxl_pergrp");
			request.AddQueryParameter("oslc.select", "*");
			request.AddQueryParameter("oslc.where", "allpersongroupteam.resppartygroup=\"" + mxuser.personId + "\"");


			var response = restClient.Execute(request);
			MaximoPersonGroupMember mxpergrpM =
				JsonConvert.DeserializeObject<MaximoPersonGroupMember>(response.Content);
			foreach (MaximoPersonGroup mxpergrp in mxpergrpM.member)
			{
				persongrops += ",\"" + mxpergrp.persongroup + "\"";
			}

			return persongrops;
		}

		// methods

		public List<MaximoWorkOrder> getWorkOrders()
		{
			string where = "failurecode=\"CATCHBASIN\"" +
			               " and siteid=\"DWS_DSS\"" +
			               " and service=\"DSS\"" +
			               " and historyflag=0" +
			               " and status=\"DISPTCHD\"" +
			               " and worktype in [\"INV\",\"EMERG\",\"PM\"]" +
			               " and persongroup in [" + findPersonGroup() + "]" +
			               " and schedstart<=\"" + System.DateTime.UtcNow.ToString("yyyy-MM-dd'T'HH:mm:ss") + "\"";

			var request = createRequest("/os/mxwo");
			request.AddQueryParameter("oslc.where", where);
			request.AddQueryParameter("oslc.select", "*");
			request.AddQueryParameter("oslc.pageSize", "10");
			request.AddQueryParameter("pageno", "1");

			var response = restClient.Execute(request);

			if (!response.IsSuccessful)
			{
				Console.WriteLine("rest-service-error : " + response.StatusCode + " - [" + response.Content + "]");
				return new List<MaximoWorkOrder>();
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
					Console.WriteLine("rest-service-error : " + response.StatusCode + " - [" + response.Content + "]");
					// todo - throw exception here?
					return maximoWorkOrderList;
				}

				mxwoPageableRestResponse =
					JsonConvert.DeserializeObject<MaximoWorkOrderPageableRestResponse>(response.Content);
				maximoWorkOrderList.AddRange(mxwoPageableRestResponse.member);
			}
			
			return maximoWorkOrderList;
		}

        public List<MaximoWorkOrderSpec> getWorkOrderSpec(string workOrderHref)
        {
            var request = createRequest(workOrderHref+"/workorderspec", true);
            request.AddQueryParameter("oslc.select", "*");
            var response = restClient.Execute(request);

            if (!response.IsSuccessful)
            {
                Console.WriteLine("rest-service-error : " + response.StatusCode + " - [" + response.Content + "]");
                return new List<MaximoWorkOrderSpec>();
            }

            List<MaximoWorkOrderSpec> maximoWorkOrderSpecList = new List<MaximoWorkOrderSpec>();

            MaximoWorkOrderSpecPageableRestResponse mxwospecPageableRestResponse =
                JsonConvert.DeserializeObject<MaximoWorkOrderSpecPageableRestResponse>(response.Content);
            maximoWorkOrderSpecList.AddRange(mxwospecPageableRestResponse.member);

            // get next pages if there is any
            while (mxwospecPageableRestResponse.responseInfo.nextPage != null)
            {
                request = createRequest(mxwospecPageableRestResponse.responseInfo.nextPage.href, true);

                response = restClient.Execute(request);

                if (!response.IsSuccessful)
                {
                    Console.WriteLine("rest-service-error : " + response.StatusCode + " - [" + response.Content + "]");
                    // todo - throw exception here?
                    return maximoWorkOrderSpecList;
                }

                mxwospecPageableRestResponse =
                    JsonConvert.DeserializeObject<MaximoWorkOrderSpecPageableRestResponse>(response.Content);
                maximoWorkOrderSpecList.AddRange(mxwospecPageableRestResponse.member);
            }

            return maximoWorkOrderSpecList;

        }

        public MaximoWorkOrderFailureRemark getWorkOrderFailureRemark(string workOrderHref)
        {
            var request = createRequest(workOrderHref + "/failureremark", true);
            request.AddQueryParameter("oslc.select", "*");
            var response = restClient.Execute(request);

            if (!response.IsSuccessful)
            {
                Console.WriteLine("rest-service-error : " + response.StatusCode + " - [" + response.Content + "]");
                return new MaximoWorkOrderFailureRemark();
            }

            
            FailureRemarkPageableRestResponse mxwospecPageableRestResponse =
                JsonConvert.DeserializeObject<FailureRemarkPageableRestResponse>(response.Content);

            return mxwospecPageableRestResponse.member.Count > 0 ? mxwospecPageableRestResponse.member[0] : new MaximoWorkOrderFailureRemark();
        }

        public List<MaximoWorkOrderFailureReport> getWorkOrderFailureReport(string workOrderHref)
        {
            var request = createRequest(workOrderHref + "/failurereport", true);
            request.AddQueryParameter("oslc.select", "*");
            var response = restClient.Execute(request);

            if (!response.IsSuccessful)
            {
                Console.WriteLine("rest-service-error : " + response.StatusCode + " - [" + response.Content + "]");
                return new List<MaximoWorkOrderFailureReport>();
            }

            FailureReportPageableRestResponse frPageableRestResponse =
                JsonConvert.DeserializeObject<FailureReportPageableRestResponse>(response.Content);
            return frPageableRestResponse.member ?? new List<MaximoWorkOrderFailureReport>();
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
                Console.WriteLine("rest-service-error : " + response.StatusCode + " - [" + response.Content + "]");
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
                    Console.WriteLine("rest-service-error : " + response.StatusCode + " - [" + response.Content + "]");
                    // todo - throw exception here?
                    return FailureLists;
                }

                flPageableRestResponse =
                    JsonConvert.DeserializeObject<FailureListPageableRestResponse>(response.Content);
                FailureLists.AddRange(flPageableRestResponse.member);
            }

            return FailureLists;

        }

        public bool updateWorkOrder(MaximoWorkOrder maximoWorkOrder)
		{
			var request = createRequest(maximoWorkOrder.href, true, Method.POST);
			request.AddHeader("x-method-override", "PATCH");

			request.AddJsonBody(maximoWorkOrder);
			
			var response = restClient.Execute(request);
			Console.WriteLine($"/mxwo - update operation response : {response.Content}");
			
			return response.IsSuccessful;
		} 

		public bool updateAssetSpec(MaximoAssetSpec maximoAssetSpec)
		{
			var request = createRequest(maximoAssetSpec.localref, true, Method.POST);
			request.AddHeader("x-method-override", "PATCH");

			request.AddJsonBody(maximoAssetSpec);
			
			var response = restClient.Execute(request);
			Console.WriteLine($"/mxasset/refid/assetspec - update operation response : {response.Content}");
			
			return response.IsSuccessful;
		}

        public bool updateAsset(MaximoAsset maximoAsset)
        {
            var request = createRequest(maximoAsset.href, true, Method.POST);
            request.AddHeader("x-method-override", "PATCH");
           

            request.AddJsonBody(maximoAsset);

            var response = restClient.Execute(request);
            Console.WriteLine($"/mxasset - update operation response : {response.Content}");

            return response.IsSuccessful;
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
				Console.WriteLine("rest-service-error : " + response.StatusCode + " - [" + response.Content + "]");
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
					Console.WriteLine("rest-service-error : " + response.StatusCode + " - [" + response.Content + "]");
					// todo - throw exception here?
					return maximoAttributes;
				}

				mxl_assetattributePageableRestResponse =
					JsonConvert.DeserializeObject<MaximoAttributePageableRestResponse>(response.Content);
				maximoAttributes.AddRange(mxl_assetattributePageableRestResponse.member);
			}
			
			return maximoAttributes;
			
		}
		
		
		public List<MaximoDomain> getDomains()
		{
			var request = createRequest("/os/mxdomain");
			request.AddQueryParameter("oslc.select", "*");
			request.AddQueryParameter("oslc.pageSize", "10");
			request.AddQueryParameter("pageno", "1");
			
			var response = restClient.Execute(request);
			
			if (!response.IsSuccessful)
			{
				Console.WriteLine("rest-service-error : " + response.StatusCode + " - [" + response.Content + "]");
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
					Console.WriteLine("rest-service-error : " + response.StatusCode + " - [" + response.Content + "]");
					// todo - throw exception here?
					return maximoDomains;
				}

				mxdomainPageableRestResponse =
					JsonConvert.DeserializeObject<MaximoDomainPageableRestResponse>(response.Content);
				maximoDomains.AddRange(mxdomainPageableRestResponse.member);
			}
			
			return maximoDomains;
			
		}
		
		public MaximoAsset getAsset(string assetnum)
		{
			if (assetnum == null) return null;
			var request = createRequest("/os/mxasset");
			request.AddQueryParameter("oslc.where", "assetnum=" + assetnum);
			request.AddQueryParameter("oslc.select", "*");
			request.AddQueryParameter("oslc.pageSize", "1");

			var response = restClient.Execute(request);
			MaximoAssetRestResponse mxAssetRestResponse =
				JsonConvert.DeserializeObject<MaximoAssetRestResponse>(response.Content);

			if (mxAssetRestResponse.member.Count > 0)
			{
				return mxAssetRestResponse.member[0];
			}
			else
			{
				return null;
			}
		}
	}
}