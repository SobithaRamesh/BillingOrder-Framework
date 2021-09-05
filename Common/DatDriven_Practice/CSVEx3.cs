using Common.Model;
using LumenWorks.Framework.IO.Csv;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BillingOrder_Framework.Common.Debug
{
    class CSVEx3
    {
        [TestCaseSource("TestData")]
        public void CSVTest(Billing bill)
        {
            TestContext.WriteLine(bill.FirstName);
            TestContext.WriteLine(bill.LastName);
            TestContext.WriteLine(bill.Email);
        }

        static IEnumerable<TestCaseData> TestData()
        {
            string Filename = "Common\\TestData\\InputData.csv";
            string currentdir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
            string completePath = currentdir + Filename;
            using (var csv = new CsvReader(new StreamReader(completePath), true))
            {
                while (csv.ReadNextRecord())
                {
                    Billing bill = new Billing(firstName: csv["firstName"], lastname: csv["lastname"], email: csv["email"]);

                    if (csv["remove"].Equals("1"))

                        yield return new TestCaseData(bill);
                }
            }

        }
    }
}
