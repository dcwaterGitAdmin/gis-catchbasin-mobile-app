using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using RestSharp;
using MaximoServiceLibrary.model;

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
		private RestClient restClient;
		private string token;
		private string sessionId;

		// public
		public MaximoUser mxuser;
		public LoginDelegateHandler loginDelegate;
		public LogoutDelegateHandler logoutDelegate;
		public bool isUserLoggedIn = false;


		// delegate
		public delegate void LoginDelegateHandler();

		public delegate void LogoutDelegateHandler();

		// cons
		public MaximoService()
		{
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
			request.AddQueryParameter("lean", "1");
			request.AddCookie(_jsessionid_Cookie_Name, sessionId);
			request.AddCookie(_ltpatoken2_Cookie_Name, token);

			return request;
		}

		public bool login(string username, string password)
		{
			string maxauth = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(username + ":" + password));
			var request = new RestRequest(BASE_URL + "/rest/login");

			request.AddHeader("Authorization", "Basic " + maxauth);
			request.Method = Method.GET;
			request.AddHeader("Accept", "application/xml,text/xml");

			var response = restClient.Execute(request);

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

		public void logout()
		{
			loginDelegate();
		}

		public void whoami()
		{
			var request = createRequest("/whoami");

			var response = restClient.Execute(request);

			mxuser = JsonConvert.DeserializeObject<MaximoUser>(response.Content);
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

			/*
			 * for each work order, fetch its details 
			 */
			foreach (var maximoWorkOrder in maximoWorkOrderList)
			{
				//maximoWorkOrder.asset = getAsset(maximoWorkOrder.assetnum);
			}

			Console.WriteLine($"Fetched {maximoWorkOrderList.Count} work orders");
			return maximoWorkOrderList;
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