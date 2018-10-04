using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace POMJoomlaTest.PageObjects
{


    public class MediaPage : CommonPage
    {
        [FindsBy(How = How.Id, Using = "toolbar-upload")]
        public IWebElement btnUpload;
        [FindsBy(How = How.Id, Using = "upload-file")]
        public IWebElement btnChooseFile;
        [FindsBy(How = How.Id, Using = "upload-submit")]
        public IWebElement btnStartUpload;
        [FindsBy(How = How.Id, Using = "folderframe")]
        public IWebElement frameFolder;

        public MediaPage(IWebDriver driver) : base(driver)
        {
        }
        public void chooseFileUpload(string path)
        {            
            clickControl(btnUpload);            
            btnChooseFile.SendKeys(path);
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Thread.Sleep(500);
            clickControl(btnStartUpload);
        }
        public void deleteImage(string imageTitle)
        {
            switchToFrame(frameFolder);
            driver.FindElement(By.XPath("//div[@class='imgDelete']/a[@rel='" + imageTitle + "']")).Click();
            switchToDefault();
        }
        public void checkImageDisplay(string imageTitle)
        {
            try
            {
                Assert.IsTrue(driver.FindElement(By.XPath("//a[@title='" + imageTitle + "']/ancestor::li[@class='imgOutline thumbnail center']")).Displayed);
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine(e);
            }
        }
        public void checkImageNotExist(string imageTitle)
        {
            try
            {
                Assert.IsFalse(driver.FindElement(By.XPath("//a[@title='" + imageTitle + "']/ancestor::li[@class='imgOutline thumbnail center']")).Displayed);
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine(e);
            }
        }
    }    
}
