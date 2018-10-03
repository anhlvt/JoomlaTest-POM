using POMJoomlaTest.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excel = Microsoft.Office.Interop.Excel;




namespace POMJoomlaTest
{

    [TestClass]
    public class ArticleTestCase : TestBase
    {
        public TestContext TestContext { get; set; }
        HomePage homePage;
        ArticlePage articlePage;
        
        [TestMethod]
        [DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+ CommonValue.path +";Persist Security Info = False;Extended Properties = 'Excel 12.0 xml;HDR=Yes;'", "TestCase1$", DataAccessMethod.Sequential)]
        [Owner("Tuan Anh")]
        [TestCategory("Article")]        
        [Description("Verify user can create new article with valid information")]
        public void TC_JOOMLA_ARTICLE_001()
        {
            homePage = new HomePage(driver);
            articlePage = new ArticlePage(driver);            
            string message = "Article saved.";
            string title = TestContext.DataRow["Title"].ToString();
            string categoryItem = TestContext.DataRow["Category"].ToString();
            string description = TestContext.DataRow["Description"].ToString();
            homePage.goToArticlePage();
            articlePage.addNewArticle(title, categoryItem, description: description);
            articlePage.verifyControlMessage(articlePage.successMessage, message);
            articlePage.checkArticleDisplay(title, categoryItem);
        }

        [TestMethod]
        [DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + CommonValue.path + ";Persist Security Info = False;Extended Properties = 'Excel 12.0 xml;HDR=Yes;'", "TestCase2$", DataAccessMethod.Sequential)]
        [Owner("Tuan Anh")]
        [TestCategory("Article")]
        [Description("Verify user can edit an article")]
        public void TC_JOOMLA_ARTICLE_002()
        {
            homePage = new HomePage(driver);
            articlePage = new ArticlePage(driver);
            string title = TestContext.DataRow["Title"].ToString();
            string titleEdit = TestContext.DataRow["TitleEdit"].ToString();
            string categoryItem = TestContext.DataRow["Category"].ToString();
            string categoryItemEdit = TestContext.DataRow["CategoryEdit"].ToString();
            string description = TestContext.DataRow["Description"].ToString();
            string message = "Article saved.";

            homePage.goToArticlePage();
            articlePage.addNewArticle(title, categoryItem, description: description);
            //articlePage.verifyControlMessage(articlePage.successMessage, "Article saved.");
            articlePage.checkArticleDisplay(title, categoryItem);
            articlePage.selectByTitle(title);
            articlePage.editArticle(titleEdit, categoryItemEdit);
            articlePage.verifyControlMessage(articlePage.successMessage, message);
            articlePage.checkArticleDisplay(titleEdit, categoryItemEdit);
        }

        [TestMethod]
        [Owner("Tuan Anh")]
        [TestCategory("Article")]
        [Description("Verify user can publish an unpublished article")]
        public void TC_JOOMLA_ARTICLE_003()
        {
            homePage = new HomePage(driver);
            articlePage = new ArticlePage(driver);
            string title = "Article Test " + rdn.Next(10000);
            string statusItem = "Unpublished";
            string categoryItem = "Sample Data-Articles";
            string description = "this is article content";
            string message = "1 article published.";
            string statusItemModify = "Published";

            homePage.goToArticlePage();
            articlePage.addNewArticle(title, categoryItem, statusItem: statusItem, description: description);
            //articlePage.verifyControlMessage(articlePage.successMessage, "Article saved.");
            articlePage.checkArticleDisplay(title, categoryItem, statusItem);
            articlePage.selectByTitle(title);
            articlePage.clickControl(articlePage.btnPublish);
            articlePage.verifyControlMessage(articlePage.successMessage, message);
            articlePage.checkArticleDisplay(title, categoryItem, statusItemModify);
        }

        [TestMethod]
        [Owner("Tuan Anh")]
        [TestCategory("Article")]
        [Description("Verify user can unpublish a published article")]
        public void TC_JOOMLA_ARTICLE_004()
        {
            homePage = new HomePage(driver);
            articlePage = new ArticlePage(driver);
            string title = "Article Test " + rdn.Next(10000);
            string statusItem = "Published";
            string categoryItem = "Sample Data-Articles";
            string description = "this is article content";
            string message = "1 article unpublished.";
            string statusItemModify = "Unpublished";

            homePage.goToArticlePage();
            articlePage.addNewArticle(title, categoryItem, statusItem: statusItem, description: description);
            //articlePage.verifyControlMessage(articlePage.successMessage, message);
            articlePage.checkArticleDisplay(title, categoryItem, statusItem);
            articlePage.selectByTitle(title);
            articlePage.clickControl(articlePage.btnUnpublish);
            articlePage.verifyControlMessage(articlePage.successMessage, message);
            articlePage.checkArticleDisplay(title, categoryItem, statusItemModify);
        }

        [TestMethod]
        [Owner("Tuan Anh")]
        [TestCategory("Article")]
        [Description("Verify user can move an article to the archive")]
        public void TC_JOOMLA_ARTICLE_005()
        {
            homePage = new HomePage(driver);
            articlePage = new ArticlePage(driver);
            string title = "Article Test " + rdn.Next(10000);
            string statusItem = "Published";
            string categoryItem = "Sample Data-Articles";
            string description = "this is article content";
            string message = "1 article archived.";
            string statusItemModify = "Archived";
            string statusFilterItem = "Archived";

            homePage.goToArticlePage();
            articlePage.addNewArticle(title, categoryItem, statusItem: statusItem, description: description);
            //articlePage.verifyControlMessage(articlePage.successMessage, "Article saved.");
            articlePage.checkArticleDisplay(title, categoryItem, statusItem);
            articlePage.selectByTitle(title);
            articlePage.clickControl(articlePage.btnArchive);
            articlePage.verifyControlMessage(articlePage.successMessage, message);
            articlePage.clickControl(articlePage.btnSearchTool);
            articlePage.selectDropDown(articlePage.cboStatusFilter, statusFilterItem);
            articlePage.checkArticleDisplay(title, categoryItem, statusItemModify);
        }
    }
}

