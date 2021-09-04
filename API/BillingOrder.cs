using APIAutomation.Test;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIAutomation.API
{
    class BillingOrder
    {
        string baseUrl = "http://localhost:8181/BillingOrder/";
       // string jsonBody = "{\"addressLine1\":\"abcd\",\"addressLine2\":\"xyz\"," +
       //"\"city\":\"weliington\",\"comment\":\"testcomment\",\"email\":\"risu@gmail.com\"," +
       //"\"firstName\":\"Sobi\",\"itemNumber\":0,\"lastName\":\"Ramesh\"," +
       //"\"phone\":\"1234512345\",\"state\":\"AL\",\"zipCode\":\"123456\"}";

        public IRestResponse GetAll()
        {
            // create
            var client = new RestClient(baseUrl);
            // request
            var request = new RestRequest(Method.GET);  
            request.AddHeader("Content-Type", "application/json");
            // Execution
            return client.Execute(request);
        }

        public IRestResponse Get(string id)
        {
            var client = new RestClient(baseUrl + "/" + id);
            // We can also use this format
            // var client = new RestClient($"{baseUrl}/{id}");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            return client.Execute(request);
        }

        public IRestResponse Post(string body)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(body);
            return client.Execute(request);
        }

        public IRestResponse Put(string id, string body)
        {

            var client = new RestClient(baseUrl + "/" + id);
            var request = new RestRequest(Method.PUT);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(body);
            return client.Execute(request);
        }

        public IRestResponse Delete(string id)
        {
            var client = new RestClient($"{baseUrl}/{id}");
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("Content-Type", "application/json");
            return client.Execute(request);
         }

    }
}
