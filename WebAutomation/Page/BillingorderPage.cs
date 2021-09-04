using Common.Model;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillingOrder_Framework.WebAutomation.Page
{
    public class BillingorderPage
    {
        IWebDriver browser;

        public BillingorderPage(IWebDriver driver)
        {
            this.browser = driver;
        }

        public void FirstName(string value)
        {
            browser.FindElement(By.Id("wpforms-24-field_0")).SendKeys(value);
        }

        public void LastName(string value)
        {
            browser.FindElement(By.Id("wpforms-24-field_0-last")).SendKeys(value);
        }

        public void Email(string value)
        {
            browser.FindElement(By.Id("wpforms-24-field_1")).SendKeys(value);
        }

        public void Phone(string value)
        {
            browser.FindElement(By.Id("wpforms-24-field_2")).SendKeys(value);
        }

        public void AddressLine1(string value)
        {
            browser.FindElement(By.Id("wpforms-24-field_3")).SendKeys(value);
        }

        public void AddressLine2(string value)
        {
            browser.FindElement(By.Id("wpforms-24-field_3-address2")).SendKeys(value);
        }

        public void City(string value)
        {
            browser.FindElement(By.Id("wpforms-24-field_3-city")).SendKeys(value);
        }

        public void FillForm(Billing bill)
        {
            FirstName(bill.FirstName);
            LastName(bill.LastName);
            Email(bill.Email);
            Phone(bill.Phone);
            AddressLine1(bill.AddressLine1);
            AddressLine2(bill.AddressLine2);
            City(bill.City);
        }

        public void Login()
        {
            browser.FindElement(By.Id("wpforms-locked-24-field_form_locker_password")).SendKeys("Testing");
            browser.FindElement(By.Id("wpforms-locked-24-field_form_locker_password")).SendKeys(Keys.Enter);
        }

        public void Submit()
        {
            browser.FindElement(By.Id("wpforms-submit-24")).Click();
        }
    }
}
