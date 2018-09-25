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

namespace POMJoomlaTest.PageObjects
{
    class ArticlePage
    {
        private IWebDriver driver;
        public ArticlePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public By newBtn = By.Id("toolbar-new");
        public By editBtn = By.Id("toolbar-edit");
        public By publishBtn = By.Id("toolbar-publish");
        public By unPublishBtn = By.Id("toolbar-unpublish");
        public By featureBtn = By.Id("toolbar-featured");
        public By unFeatureBtn = By.Id("toolbar-unfeatured");
        public By archiveBtn = By.Id("toolbar-archive");
        public By checkInBtn = By.Id("toolbar-checkin");
        public By batchBtn = By.Id("toolbar-batch");
        public By trashBtn = By.Id("toolbar-trash");

        public By titleTxt = By.Id("jform_title");
        public By textFram = By.Id("jform_articletext_ifr");
        public By textArea = By.Id("tinymce");
        public By statusDropList = By.Id("jform_state");
        public By categorysDropList = By.Id("jform_catid");
        public By accessDropList = By.Id("jform_access");
        public By languageDropList = By.Id("jform_language");

        public void clickToolBarButton(By toolbar)
        {
            driver.FindElement(toolbar).Click();
        }

        public void modifyElementStatus(By droplistName, string statusDisplay)
        {
            IWebElement hiddenWebElement = driver.FindElement(droplistName);
            string strScript = "document.getElementById('jform_state').style.display = \"" + statusDisplay + "\";";
            ((IJavaScriptExecutor)driver).ExecuteScript(strScript, hiddenWebElement);
        }

        public void selectDropList(By droplistName, string statusDisplay, string items)
        {
            modifyElementStatus(droplistName, statusDisplay);
            SelectElement select = new SelectElement(driver.FindElement(droplistName));
            select.SelectByText(items);
        }

        public void fillArticleInformation(string title, string paragraph)
        {
            if (title != null)
            {
                driver.FindElement(titleTxt).Clear();
                driver.FindElement(titleTxt).SendKeys(title);
            }

            if (paragraph != null)
            {
                driver.SwitchTo().Frame(driver.FindElement(textFram));
                driver.FindElement(textArea).Clear();
                driver.FindElement(textArea).SendKeys(paragraph);
                driver.SwitchTo().DefaultContent();
            }
        }
    }
}