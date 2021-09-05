using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BillingOrder_Framework.Common.Debug
{
    class TestCaseDataEx
    {
        [TestCaseSource("TestData")]
        public int SumTest(int n1, int n2)
        {
            int sum = n1 + n2;
            return sum;
        }
 
        public static IEnumerable TestData
        {
            get
            {
                yield return new TestCaseData(12, 3).Returns(15);
                yield return new TestCaseData(12, 2).Returns(14);
                yield return new TestCaseData(12, 4).Returns(16);
            }
        }
    }
}

