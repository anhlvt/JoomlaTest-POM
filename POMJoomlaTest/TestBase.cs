using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using POMJoomlaTest.PageObjects;

namespace POMJoomlaTest
{
    [TestClass]
    public class TestBase
    {
        public IWebDriver driver;
        public LoginPage loginPage;
        public HomePage homePage;
        public ArticlePage articlePage;
        [TestInitialize]
        public void Initialize()
        {
            driver = new ChromeDriver();
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
            articlePage = new ArticlePage(driver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Window.Maximize();
            loginPage.goToWebPage();
            loginPage.login("lctp", "lctp");
        }

    }
}
