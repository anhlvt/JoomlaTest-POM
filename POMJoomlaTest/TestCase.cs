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
            driver.Manage().Window.Maximize();
            login = new LoginPage(driver);
            login.goToPage();
            login.login("lctp", "lctp");
        }

        [TestMethod]
        public void TC_JOOMLA_ARTICLE_001()        
        {            
            home = new HomePage(driver);
            home.goToArticlePage();
            article = new ArticlePage(driver);
            article.clickToolBarButton(article.newBtn);
            article.fillArticleInformation("anhlvt", "this is article");
            //article.selectDropList(article.statusDropList, "block",);
            article.selectDropList(article.categorysDropList, "block", "- Park Site");
        }


        [TestCleanup]
        public void TearDown()
        {
           // driver.Close();
        }
    }
}
