using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillingOrder_Framework.Common.Debug
{
    class LoopEx
    {
        [TestCaseSource("TestData")]
        public void CSVTest(string name)
        {
            TestContext.WriteLine(name);
        }

        static IEnumerable<string> TestData()
        {
            for (int i = 0; i <= 100; i++)
                yield return "Test" + i;
        }
    }
}
