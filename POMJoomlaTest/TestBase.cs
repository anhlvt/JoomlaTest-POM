using System;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using POMJoomlaTest.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace POMJoomlaTest
{
    [TestClass]    
    public class TestBase
    {
        public IWebDriver driver;
        //public RemoteWebDriver driver;
        public LoginPage loginPage;
        public Random rdn;
        string IPAddress = "192.168.191.84";



        [TestInitialize]
        public void Initialize()
        {
            //driver = new ChromeDriver();     
            ChromeOptions options = new ChromeOptions();
            //FirefoxOptions options = new FirefoxOptions();
            options.AddArgument("--start-maximized");
            driver = new RemoteWebDriver(new Uri("http://"+IPAddress+":4444/wd/hub"), options);
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Window.Maximize();
            loginPage = new LoginPage(driver);
            rdn = new Random();
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
