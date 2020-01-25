using Microsoft.VisualStudio.TestTools.UnitTesting;
using Selenium.Automation_Accelarator.WebServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selenium.Test.WebServicesWorkflow.Reqres.Get;
using RestSharp;
using Selenium.Test.WebServicesWorkflow.Reqres.POST;

namespace Selenium.Test.WebServices
{
    [TestClass]
    public class WebServicesTest
    {
        [TestMethod]
        public void fnTestWebServices()
        {
            Console.WriteLine("Test WebServices");
            string strURL = "https://reqres.in";
            RestSharpHelper<ReqUserList> restAPI = new RestSharpHelper<ReqUserList>();
            RestClient restclient=restAPI.fnSetURL(strURL,"/api/users");
            string strjson = "?page=2";
            var restRequest = restAPI.CreateGETRequest(strjson);
            var getResponse = restAPI.GetResponse(restclient, restRequest);
            Console.WriteLine(getResponse);
            ReqUserList objReturnData = restAPI.GetContent<ReqUserList>(getResponse);
            Console.WriteLine("Total Page Found ==> " + objReturnData.total_pages);



        }
        [TestMethod]
        public void fnTestWebServicesTest()
        {
            Console.WriteLine("Test WebServices");
            string strURL = "https://reqres.in";
            RestSharpHelper<ReqUserList> restAPI = new RestSharpHelper<ReqUserList>();
            RestClient restclient = restAPI.fnSetURL(strURL, "/api/users");
            string strjson = @"{
                                ""name"": ""Pankaj"",
                                ""job"": ""Project Lead""
                               }";
            var restRequest = restAPI.CreatePOSTRequest(strjson);
            var getResponse = restAPI.GetResponse(restclient, restRequest);
            Console.WriteLine(getResponse);
            CreateUser objReturnData = restAPI.GetContent<CreateUser>(getResponse);
            Console.WriteLine("Name Found ==> " + objReturnData.name);
            Console.WriteLine("ID Found ==> " + objReturnData.id);
            Console.WriteLine("JOB Found ==> " + objReturnData.job);
            Console.WriteLine("createdAt Found ==> " + objReturnData.createdAt);



        }
    }
}
