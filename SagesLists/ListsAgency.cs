using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SagesLists
{
    [TestClass]
    public class ListsAgency
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private String baseURL;
        private bool acceptNextAlert = true;
        private StringBuilder agencyName;
		private Random randGen;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            //baseURL = new String("https://trial.sagesgov.com/");
            verificationErrors = new StringBuilder();
			randGen = new Random(100);
            agencyName = new StringBuilder("Agency");
            agencyName.Append(randGen.Next(1, 100).ToString());
			
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            NUnit.Framework.Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [TestMethod]
        public void TheListsAgencyTest()
        {
            driver = new FirefoxDriver();
            //baseURL = new String("https://trial.sagesgov.com/Account/Login.aspx");
            verificationErrors = new StringBuilder();
            randGen = new Random();
            agencyName = new StringBuilder("Agency");
            agencyName.Append(randGen.Next(1, 100).ToString());
            driver.Navigate().GoToUrl("https://trial.sagesgov.com/");  
            Thread.Sleep(3000);
            driver.FindElement(By.Id("cphContent_cphMain_Login1_txtUserName")).SendKeys(Keys.Control +  "a");
            driver.FindElement(By.Id("cphContent_cphMain_Login1_txtUserName")).SendKeys("USERNAMEHERE");            
            driver.FindElement(By.Id("cphContent_cphMain_Login1_txtPassword")).SendKeys("PASSWORDHERE");
            driver.FindElement(By.Id("cphContent_cphMain_Login1_btnLogin")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("cphContent_mainMenu1_hypAdministration")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("cphContent_cphMain_adminNavLinks_hypManageAgencies")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("cphContent_cphMain_cphRightColumn_btnAddNew")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("cphContent_cphMain_cphRightColumn_txtAgencyName")).Clear();
            driver.FindElement(By.Id("cphContent_cphMain_cphRightColumn_txtAgencyName")).SendKeys(agencyName.ToString());
            driver.FindElement(By.Id("cphContent_cphMain_cphRightColumn_txtPosition")).Clear();
            driver.FindElement(By.Id("cphContent_cphMain_cphRightColumn_txtPosition")).SendKeys("1");
            driver.FindElement(By.Id("cphContent_cphMain_cphRightColumn_btnSave")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.PartialLinkText(agencyName.ToString())).Click();
            driver.FindElement(By.Id("cphContent_cphMain_cphRightColumn_txtAgencyName")).Clear();
            driver.FindElement(By.Id("cphContent_cphMain_cphRightColumn_txtAgencyName")).SendKeys(agencyName.ToString());
            driver.FindElement(By.Id("cphContent_cphMain_cphRightColumn_btnSave")).Click();
            driver.FindElement(By.CssSelector("button.toast-close-button")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        public void WaitForElementLoad(By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(ExpectedConditions.ElementIsVisible(by));
            }
        }
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
