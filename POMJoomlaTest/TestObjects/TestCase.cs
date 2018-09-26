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
using POMJoomlaTest.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace POMJoomlaTest
{

    [TestClass]
    public class TestCase
    {
        private IWebDriver driver;
        private LoginPage login;
        private HomePage home;
        private ArticlePage article;
        

        [TestInitialize]
        public void Init()
        {
            driver = new ChromeDriver();
            login = new LoginPage(driver);
            home = new HomePage(driver);
            article = new ArticlePage(driver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);            
            driver.Manage().Window.Maximize();
            login.goToPage();
            login.login("lctp", "lctp");
        }

        [TestMethod]
        public void TC_JOOMLA_ARTICLE_001()        
        {
            home.goToArticlePage();
            article.clickToolBarButton(article.New);
            article.fillArticleInformation("Article Test", null, "Sample Data-Articles", "this is article");
            article.selectSaveType(article.SaveAndClose);
        }
        public void TC_JOOMLA_ARTICLE_002()
        {
            home.goToArticlePage();
            article.clickToolBarButton(article.New);
            article.fillArticleInformation("Article Test", null, "Sample Data-Articles", "this is article");
            article.selectSaveType(article.SaveAndClose);
            article.clickToolBarButton(article.Edit);
            article.fillArticleInformation("Article Test_update", null, "- Park Site", "this is article");
            article.selectSaveType(article.SaveAndClose);
        }


        [TestCleanup]
        public void TearDown()
        {
           // driver.Close();
        }
    }
}
