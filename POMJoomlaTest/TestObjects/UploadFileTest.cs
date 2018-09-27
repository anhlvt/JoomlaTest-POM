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
        MediaPage mediaPage;
        HomePage homePage;
        

        [TestMethod]
        public void Upload_File_Test()
        {
            string titleImage = "quality.jpg";
            string messageUpload = "Upload Complete: \\" + titleImage ;
            string messageDelete = "Delete Complete: \\" + titleImage;
            string path = "C:\\quality.jpg";
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
 
