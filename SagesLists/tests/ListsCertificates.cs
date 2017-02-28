using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SagesLists.tests
{
    [TestClass]
    public class ListsCertificates
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        [TestMethod]
        public void TestAddCertificate()
        {
            driver = new FirefoxDriver();
            baseURL = "https://trial.sagesgov.com/";
            verificationErrors = new StringBuilder();
            driver.Navigate().GoToUrl(baseURL + "Admin/Agencies.aspx");
            driver.FindElement(By.Id("cphContent_cphMain_cphLeftColumn_adminNav_lnkCertificates")).Click();
            driver.FindElement(By.Id("cphContent_cphMain_cphRightColumn_btnAddNew")).Click();
            driver.FindElement(By.Id("cphContent_cphMain_cphRightColumn_txtSubClass")).Clear();
            driver.FindElement(By.Id("cphContent_cphMain_cphRightColumn_txtSubClass")).SendKeys("TestCertificate2");
            driver.FindElement(By.Id("cphContent_cphMain_cphRightColumn_txtCode")).Clear();
            driver.FindElement(By.Id("cphContent_cphMain_cphRightColumn_txtCode")).SendKeys("21");
            new SelectElement(driver.FindElement(By.Id("cphContent_cphMain_cphRightColumn_ddlAgency"))).SelectByText("Building Electrical");
            new SelectElement(driver.FindElement(By.Id("cphContent_cphMain_cphRightColumn_numTemplate_ddlNumberFields"))).SelectByText("Next Sequence");
            driver.FindElement(By.Id("cphContent_cphMain_cphRightColumn_numTemplate_hypInsert")).Click();
            driver.FindElement(By.Id("cphContent_cphMain_cphRightColumn_txtPosition")).Clear();
            driver.FindElement(By.Id("cphContent_cphMain_cphRightColumn_txtPosition")).SendKeys("1");
            driver.FindElement(By.LinkText("System.Current Date")).Click();
            driver.FindElement(By.Id("cphContent_cphMain_cphRightColumn_btnSave")).Click();
            driver.FindElement(By.Id("cphContent_cphMain_cphRightColumn_gvEntityList_lbtEdit_0")).Click();
            new SelectElement(driver.FindElement(By.Id("cphContent_cphMain_cphRightColumn_ddlAgency"))).SelectByText("Building");
            driver.FindElement(By.Id("cphContent_cphMain_cphRightColumn_btnSave")).Click();
            driver.FindElement(By.CssSelector("button.toast-close-button")).Click();
        }
    }
}
