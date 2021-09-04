using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillingOrder_Framework.WebAutomation.Framework
{
    public class BasePage
    {
        public IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Url = "http://qaauto.co.nz/billing-order-form/";
        }

        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
        }

    }
}
