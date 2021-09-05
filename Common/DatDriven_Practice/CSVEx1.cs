using LumenWorks.Framework.IO.Csv;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BillingOrder_Framework.Common.Debug
{
    class CSVEx1
    {
        [TestCaseSource("TestData")]
        public void CSVTest(string name)
        {
            TestContext.WriteLine(name);
        }

        static IEnumerable<string> TestData()
        {
            string Filename = "Common\\TestData\\InputData.csv";
            string currentdir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
            string completePath = currentdir + Filename;
            using (var csv = new CsvReader(new StreamReader(completePath), true))
            {
                while (csv.ReadNextRecord())
                   yield return csv[0];
                   // Can also do like this
                   // yield return csv["firstName"] + " " + csv["lastName"] + " " + csv["email"];
            }
                
        }
    }
}
