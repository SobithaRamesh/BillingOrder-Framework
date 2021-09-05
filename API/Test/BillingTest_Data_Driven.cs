using APIAutomation.API;
using Common.Model;
using FluentAssertions;
using LumenWorks.Framework.IO.Csv;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BillingOrder_Framework.API.Test
{
    public class BillingTest_Data_Driven
    {
        [TestCaseSource("TestData")]
        public void CreateBilllingOrder(Billing bill)
        {

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

            static  IEnumerable<TestCaseData> TestData()
            {
                string Filename = "Common\\TestData\\InputData.csv";
                string currentdir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
                string completePath = currentdir + Filename;
                using (var csv = new CsvReader(new StreamReader(completePath), true))
                {
                    while (csv.ReadNextRecord())
                    {
                        Billing bill = new Billing(firstName: csv["firstName"], lastname: csv["lastname"], email: csv["email"]);

                        yield return new TestCaseData(bill).SetName(csv["TCName"]);
                    }
                }
            }

        }
    
}
