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
        private LoginPage ojbLogin;
        private HomePage ojbHome;
        private ArticlePage ojbArticle;
        

        [TestInitialize]
        public void Init()
        {
            driver = new ChromeDriver();
            ojbLogin = new LoginPage(driver);
            ojbHome = new HomePage(driver);
            ojbArticle = new ArticlePage(driver);
            driver.Manage().Window.Maximize();
            ojbLogin.goToPage();
            ojbLogin.login("lctp", "lctp");
        }

        [TestMethod]
        public void TC_JOOMLA_ARTICLE_001()        
        {
            ojbHome.goToArticlePage();
            ojbArticle.clickToolBarButton(ojbArticle.New);
            ojbArticle.fillArticleInformation("Article Test", null, "Sample Data-Articles", "this is article");
            ojbArticle.selectSaveType(ojbArticle.SaveAndClose);
        }
        public void TC_JOOMLA_ARTICLE_002()
        {
            ojbHome.goToArticlePage();
            ojbArticle.clickToolBarButton(ojbArticle.New);
            ojbArticle.fillArticleInformation("Article Test", null, "Sample Data-Articles", "this is article");
            ojbArticle.selectSaveType(ojbArticle.SaveAndClose);            
            ojbArticle.clickToolBarButton(ojbArticle.Edit);
            ojbArticle.fillArticleInformation("Article Test_update", null, "- Park Site", "this is article");
            ojbArticle.selectSaveType(ojbArticle.SaveAndClose);
        }


        [TestCleanup]
        public void TearDown()
        {
           // driver.Close();
        }
    }
}
