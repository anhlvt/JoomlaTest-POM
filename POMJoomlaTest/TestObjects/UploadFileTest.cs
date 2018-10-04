using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using POMJoomlaTest.PageObjects;

namespace POMJoomlaTest.TestObjects
{
    [TestClass]
    public class UploadFileTest : TestBase
    {
        public TestContext TestContext { get; set; }
        MediaPage mediaPage;
        HomePage homePage;
        

        [TestMethod]
        [DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + CommonValue.path + ";Persist Security Info = False;Extended Properties = 'Excel 12.0 xml;HDR=Yes;'", "image$", DataAccessMethod.Sequential)]
        public void Upload_File_Test()
        {
            string titleImage = TestContext.DataRow["ImageTitle"].ToString();            
            string messageUpload = "Upload Complete: \\" + titleImage ;
            string messageDelete = "Delete Complete: \\" + titleImage;
            string path = "C:\\ImageSource\\"+titleImage;
            homePage = new HomePage(driver);
            mediaPage = new MediaPage(driver);
            homePage.goToMediaPage();                     
            mediaPage.chooseFileUpload(path);
            mediaPage.verifyControlMessage(mediaPage.successMessage, messageUpload);
            mediaPage.checkImageDisplay(titleImage);
            mediaPage.deleteImage(titleImage);
            mediaPage.verifyControlMessage(mediaPage.successMessage, messageDelete);
            mediaPage.checkImageNotExist(titleImage);

        }
        
    }
}
 
