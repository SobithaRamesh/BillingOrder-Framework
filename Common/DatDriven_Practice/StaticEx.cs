using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillingOrder_Framework.Common.Debug
{
    class StaticEx
    {
        [Test]
        public void Testing()
        {
            St obj1 = new St();
            obj1.name = "Temp";
            TestContext.WriteLine(obj1.name);  // will print Temp
            obj1.name = "Temp1";

            St obj2 = new St();
            TestContext.WriteLine(obj2.name);  // will print abc

            //  Static is friend of class   // No Object
            TestContext.WriteLine(St.nameS);

            TestContext.WriteLine(St.nameS);

            TestContext.WriteLine(St.nameS);

            TestContext.WriteLine(St.nameS);

            TestContext.WriteLine(St.nameS);

            //abc .. Testing Testing Tesing
        }
    }

    class St
    {
        //non static
        public string name = "abc";

        //static
        public readonly static string nameS = "abc_static";

        public St()
        {
            TestContext.WriteLine("Create object");
        }

    }
}
