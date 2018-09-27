using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using POMJoomlaTest.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace POMJoomlaTest
{
    [TestClass]
    public class TestBase
    {
        public IWebDriver driver;
        public LoginPage loginPage;
        public Random rdn;       

        [TestInitialize]
        public void Initialize()
        {
            driver = new ChromeDriver();
            loginPage = new LoginPage(driver);
            rdn = new Random();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Window.Maximize();
            loginPage.goToWebPage();
            loginPage.login("lctp", "lctp");
        }

        [TestCleanup]
        public void CleanUp()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void WaitForPageLoad(IWebDriver driver, int timeoutSec = 15)
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, timeoutSec));
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
            wait.Until(d => (bool)(d as IJavaScriptExecutor).ExecuteScript("return jQuery.active == 0"));
        }
    }
}
