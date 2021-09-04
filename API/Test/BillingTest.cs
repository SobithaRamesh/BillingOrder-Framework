using APIAutomation.API;
using Common.Model;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIAutomation.Test
{ 
    [Author("Sobitha")]
    class BillingTest
    {
        [Test]
        public void GetAllBilllingOrder()
        {
            BillingOrder BillingAPI = new BillingOrder();
            IRestResponse response = BillingAPI.GetAll();
            // Deserialize the response into a list and query them individually using loop
            var response_list = JsonConvert.DeserializeObject<List<Billing>>(response.Content);
            //TestContext.WriteLine(response_list[0].Id);
            foreach (Billing element in response_list)
            {
                if (element.FirstName == "Sobi")
                {
                    TestContext.WriteLine(element.Id);
                }
            }
        }

        [Test]
        public void GetBilllingOrder()
        {
            BillingOrder BillingAPI = new BillingOrder();
            IRestResponse response = BillingAPI.Get("1");
            TestContext.WriteLine(response.Content);
            TestContext.WriteLine(response.StatusCode);

            int resp_sts = (int)response.StatusCode;
            if (resp_sts == 200)
            {
                Assert.Pass();
            }
            else 
            {
                Assert.Fail("Response from server is " + response.StatusCode + " with response code " + resp_sts.ToString());
            }
        }

        [Test]
        // [Repeat(10)]  -->  Execute 10 times (ie)., Create 10 records
        public void CreateBilllingOrder()
        {
            //Constructor
            Billing bill = new Billing();
            bill.AddressLine1 = "16";
            bill.AddressLine2 = "abcd";
            bill.City = "aa";
            bill.Comment = "test1";
            bill.ItemNumber = 1;
            bill.Email = "risu@gmail.com";
            bill.FirstName = "Sobi";
            bill.LastName = "Ramesh";
            bill.Phone = "1234512345";
            bill.State = "TN";
            bill.ZipCode = "123456";

            // Serialize JSON  -->  object to json
            string jsonBody = JsonConvert.SerializeObject(bill);
            BillingOrder BillingAPI = new BillingOrder();

            // Creating order
            IRestResponse response = BillingAPI.Post(jsonBody);

            // Deserialize JSON  -->  json to object
            Billing actualbill = JsonConvert.DeserializeObject<Billing>(response.Content);

            int resp_sts = (int)response.StatusCode;
            if (resp_sts == 200)
            {
                response = BillingAPI.Get(actualbill.Id);
                resp_sts = (int)response.StatusCode;
                if (resp_sts == 200)
                {
                    actualbill = JsonConvert.DeserializeObject<Billing>(response.Content);

                    /* Compare expected(bill) to actual(actualbill)
                       But not to compare Id                        */
                    actualbill.Should().BeEquivalentTo(bill,
                    options => options.Excluding(o => o.Id));
                }
                else 
                {
                    Assert.Fail();
                }
            }
            else
            {
                Assert.Fail();
            }

        }

        [Test]
         public void UpdateBilllingOrder()
         {
            Billing bill = new Billing();
            bill.AddressLine1 = "16";
            bill.AddressLine2 = "abcd";
            bill.City = "aa";  
            bill.Comment = "Updated";
            bill.ItemNumber = 1;
            bill.Email = "risu@gmail.com";
            bill.FirstName = "Sobitha";
            bill.LastName = "Ramesh";
            bill.Phone = "1234512345";
            bill.State = "TN";
            bill.ZipCode = "123456";
            bill.Id = "2";
            string jsonBody = JsonConvert.SerializeObject(bill);
            BillingOrder BillingAPI = new BillingOrder();
            IRestResponse response = BillingAPI.Put(bill.Id,jsonBody);
            Billing actualbill = JsonConvert.DeserializeObject<Billing>(response.Content);

            int resp_sts = (int)response.StatusCode;
            if (resp_sts == 200)
            {
                response = BillingAPI.Get(bill.Id);
                resp_sts = (int)response.StatusCode;
                if (resp_sts == 200)
                {
                    actualbill = JsonConvert.DeserializeObject<Billing>(response.Content);

                    // Compare expected(bill) to actual(actualbill)
                    actualbill.Should().BeEquivalentTo(bill);
                }
                else
                {
                    Assert.Fail();
                }
            }
            else
            {
                Assert.Fail();
            }
        } 

         [Test]
         public void DeleteBilllingOrder()
         {
            BillingOrder BillingAPI = new BillingOrder();
            IRestResponse response = BillingAPI.Delete("4");
            int resp_sts = (int)response.StatusCode;
            if (resp_sts == 200)
            {
                response = BillingAPI.Get("4");
                resp_sts = (int)response.StatusCode;
                if (resp_sts == 200)
                {
                    if (response.Content == "null")
                    {
                        Assert.Pass();
                    }
                    else
                    {
                        Assert.Fail("Response from server is " + response.StatusCode + " with response code " + resp_sts.ToString());
                    }
                }
                else
                {
                    Assert.Fail("Response from server is " + response.StatusCode + " with response code " + resp_sts.ToString());
                }
            }
            else
            {
                Assert.Fail("Response from server is " + response.StatusCode + " with response code " + resp_sts.ToString());
            }
        
        }
    }
}
