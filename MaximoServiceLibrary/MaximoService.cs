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
        private static readonly string BASE_URL = "http://localhost:8080/maxrest/oslc";
        //private static readonly string BASE_URL = "https://bpl-max-test.dcwasa.com/maxrest/oslc";
        
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
            restClient = new RestClient(BASE_URL);
            loginDelegate = new LoginDelegateHandler(whoami);
          //  loginDelegate += getWorkOrders;
            logoutDelegate = new LogoutDelegateHandler(clearUserData);
        }

        // helpers
        public RestRequest createRequest(string _url)
        {
            var request = new RestRequest(_url);
            request.AddQueryParameter("lean", "1");
            request.AddCookie("JSESSIONID", sessionId);
            request.AddCookie("LtpaToken2", token);
            return request;
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
            MaximoPersonGroupMember mxpergrpM = JsonConvert.DeserializeObject<MaximoPersonGroupMember>(response.Content);
            foreach (MaximoPersonGroup mxpergrp in mxpergrpM.member)
            {
                persongrops += ",\"" + mxpergrp.persongroup + "\"";
            }
            return persongrops;

        }

        // methods
        public bool login(string username, string password)
        {
            string maxauth = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(username + ":" + password));
            var request = new RestRequest("/rest/login");

            request.AddHeader("Authorization", "Basic " + maxauth);
            request.Method = Method.GET;
            request.AddHeader("Accept", "application/xml,text/xml");

            var response = restClient.Execute(request);

            foreach (RestResponseCookie cookie in response.Cookies.ToArray())
            {

                if (cookie.Name.ToUpper() == "LtpaToken2".ToUpper())
                {
                    token = cookie.Value;
                }
                if (cookie.Name.ToUpper() == "JSESSIONID".ToUpper())
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
            //todo delete
            request.AddQueryParameter("oslc.pageSize", "10");
            var response = restClient.Execute(request);
          
            MaximoWorkOrderList mxwoList = JsonConvert.DeserializeObject<MaximoWorkOrderList>(response.Content);

            for (int i = 0; i < mxwoList.member.Count; i++)
            {
                mxwoList.member[i].asset = getAsset(mxwoList.member[i].assetnum);
            }

            return mxwoList.member;
            
        }

        public MaximoAsset getAsset(string assetnum)
        {
            if (assetnum == null) return null;
            var request = createRequest("/os/mxasset");
            request.AddQueryParameter("oslc.where", "assetnum="+assetnum);
            request.AddQueryParameter("oslc.select", "*");
            var response = restClient.Execute(request);
            MaximoAssetMember mxasstM = JsonConvert.DeserializeObject<MaximoAssetMember>(response.Content);

            if(mxasstM.member.Count > 0)
            {
                return mxasstM.member[0];
            }
            else
            {
                return null;
            }
            
        }
        



    }



}