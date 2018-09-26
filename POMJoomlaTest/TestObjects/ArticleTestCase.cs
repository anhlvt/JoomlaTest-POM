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
    public class ArticleTestCase : TestBase
    {        
        [TestMethod]
        public void TC_JOOMLA_ARTICLE_001()        
        {
            homePage.goToArticlePage();
            articlePage.addNewArticle("Article Test", null,"Sample Data-Articles",null, "this is article");
            articlePage.verifySuccessMessage(articlePage.successMessage, "Article saved.");
            articlePage.checkArticleExist("Article Test", "Sample Data-Articles");
        }

        [TestMethod]
        public void TC_JOOMLA_ARTICLE_002()
        {
            homePage.goToArticlePage();
            articlePage.addNewArticle("Article Test 123",null, "Sample Data-Articles",null, "this is article");
            articlePage.verifySuccessMessage(articlePage.successMessage, "Article saved.");
            articlePage.checkOnRecentArticle("Article Test 123");
            articlePage.editArticle("Article Test edit",null, "- Park Site", null, "this is article");
            articlePage.verifySuccessMessage(articlePage.successMessage, "Article saved.");
        }

        [TestMethod]
        public void TC_JOOMLA_ARTICLE_003()
        {
            homePage.goToArticlePage();
            articlePage.addNewArticle("Article Test 123", "Unpublished", "Sample Data-Articles",null, "this is article");
            articlePage.verifySuccessMessage(articlePage.successMessage, "Article saved.");
            articlePage.clickControl(articlePage.btnPublish);
            articlePage.verifySuccessMessage(articlePage.successMessage, "1 article published.");            
        }

        [TestMethod]
        public void TC_JOOMLA_ARTICLE_004()
        {
            homePage.goToArticlePage();
            articlePage.addNewArticle("Article Test 123", "Published", "Sample Data-Articles", null, "this is article");
            articlePage.verifySuccessMessage(articlePage.successMessage, "Article saved.");
            articlePage.clickControl(articlePage.btnUnpublish);
            articlePage.verifySuccessMessage(articlePage.successMessage, "1 article unpublished.");
        }

        [TestMethod]
        public void TC_JOOMLA_ARTICLE_005()
        {
            homePage.goToArticlePage();
            articlePage.addNewArticle("Article Test 1234", "Published", "Sample Data-Articles", null, "this is article");
            articlePage.verifySuccessMessage(articlePage.successMessage, "Article saved.");
            articlePage.clickControl(articlePage.btnArchive);
            articlePage.verifySuccessMessage(articlePage.successMessage, "1 article archived.");
            articlePage.clickControl(articlePage.btnSearchTool);
            articlePage.selectDropDown(articlePage.cboStatusFilter,"Archived");
        }
        [TestCleanup]
        public void CleanUp()
        {
           driver.Quit();
        }
    }
}
