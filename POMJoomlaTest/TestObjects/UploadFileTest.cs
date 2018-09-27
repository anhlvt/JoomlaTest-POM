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
            string path = "C:\\quality.jpg";
            homePage = new HomePage(driver);
            mediaPage = new MediaPage(driver);
            homePage.goToMediaPage();                     
            mediaPage.chooseFileUpload(path);
        }

    }
}
