using BillingOrder_Framework.WebAutomation.Framework;
using BillingOrder_Framework.WebAutomation.Page;
using Common.Model;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillingOrder_Framework.WebAutomation.Test
{
    class BillingOrderTest : BasePage
    {
   
        [Test]
        public void createBillingOrderTest()
        {
            BillingorderPage orderpage = new BillingorderPage(driver);
            orderpage.Login();

            Billing bill = new Billing();
            bill.AddressLine1 = "16";
            bill.AddressLine2 = "abcd";
            bill.City = "aa";
            bill.Email = "risu@gmail.com";
            bill.FirstName = "Sobi";
            bill.LastName = "Ramesh";
            bill.Phone = "1234512345";

            orderpage.FillForm(bill);
            orderpage.Submit();
        }
    }
}
