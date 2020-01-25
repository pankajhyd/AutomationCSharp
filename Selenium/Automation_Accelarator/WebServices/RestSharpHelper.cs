using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Automation_Accelarator.WebServices
{
    public class RestSharpHelper<T>
    {
        public RestClient restClient;
        public RestRequest restRequest;
        public string baseURL;
        public void fnSetBaseURL(String strBaseURL)
        {
            baseURL = strBaseURL;
        }

        public RestClient fnSetURL(string strBaseURL,string strResourceURL)
        {
            Console.WriteLine(strBaseURL);
            Console.WriteLine(strResourceURL);
            var url = strBaseURL+strResourceURL;
            Console.WriteLine(url);
            var restClient = new RestClient(url);
            return restClient;
        }
        public RestRequest CreatePOSTRequest(string jsonstring)
        {
            restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddParameter("application/json", jsonstring,ParameterType.RequestBody);
            return restRequest;
        }

        public RestRequest CreateGETRequest(string jsonstring)
        {
            restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("Accept", "application/json");
            //restRequest.AddParameter("application/json", jsonstring, ParameterType.RequestBody);
            return restRequest;
        }

        public RestRequest CreateDELETERequest(string jsonstring)
        {
            restRequest = new RestRequest(Method.DELETE);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddParameter("application/json", jsonstring, ParameterType.RequestBody);
            return restRequest;
        }

        public RestRequest CreatePUTRequest(string jsonstring)
        {
            restRequest = new RestRequest(Method.PUT);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddParameter("application/json", jsonstring, ParameterType.RequestBody);
            return restRequest;
        }

        public IRestResponse GetResponse(RestClient restclient,RestRequest restrequest)
        {
            return restclient.Execute(restrequest);
        }

        public DTO GetContent<DTO>(IRestResponse response)
        {
            var content = response.Content;
            DTO deserizedresponse = Newtonsoft.Json.JsonConvert.DeserializeObject<DTO>(content);
            return deserizedresponse;
        }
    }
}
