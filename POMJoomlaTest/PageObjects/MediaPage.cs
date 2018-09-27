using System;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Remote;
using System.IO;
using System.Threading;

namespace POMJoomlaTest.PageObjects
{
    

   public class MediaPage : CommonPage
    {
        private IWebElement driver;
        [FindsBy(How = How.Id, Using = "toolbar-upload")]
        public IWebElement btnUpload;
        [FindsBy(How = How.Id, Using = "upload-file")]
        public IWebElement btnChooseFile;
        [FindsBy(How = How.Id, Using = "upload-submit")]
        public IWebElement btnStartUpload;

        public MediaPage(IWebDriver driver) : base(driver)
        {
        }

        public void chooseFileUpload(string path)
        {
            clickControl(btnUpload);            
            btnChooseFile.SendKeys(path);
            //Thread.Sleep(1000);
            clickControl(btnStartUpload);       
        }
               
        
    }
}
