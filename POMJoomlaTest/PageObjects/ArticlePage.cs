using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace POMJoomlaTest.PageObjects
{
    public class ArticlePage : CommonPage
    {
        private IWebDriver driver;

        public ArticlePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //toolbar button
        [FindsBy(How = How.Id, Using = "toolbar-new")]
        public IWebElement btnNew;
        [FindsBy(How = How.Id, Using = "toolbar-edit")]
        public IWebElement btnEdit;
        [FindsBy(How = How.Id, Using = "toolbar-publish")]
        public IWebElement btnPublish;
        [FindsBy(How = How.Id, Using = "toolbar-unpublish")]
        public IWebElement btnUnpublish;
        [FindsBy(How = How.Id, Using = "toolbar-archive")]
        public IWebElement btnArchive;
        //save type
        [FindsBy(How = How.CssSelector, Using = "#toolbar-apply > button")]
        public IWebElement btnSave;
        [FindsBy(How = How.CssSelector, Using = "#toolbar-save > button")]
        public IWebElement btnSaveAndClose;
        [FindsBy(How = How.CssSelector, Using = "#toolbar-save-new > button")]
        public IWebElement btnSaveAndNew;
        [FindsBy(How = How.CssSelector, Using = "#toolbar-cancel > button")]
        public IWebElement btnCancel;
        //        
        [FindsBy(How = How.Id, Using = "jform_title")]
        public IWebElement txtTitle;
        [FindsBy(How = How.Id, Using = "jform_state")]
        public IWebElement cboStatus;
        [FindsBy(How = How.Id, Using = "jform_catid")]
        public IWebElement cboCategory;
        [FindsBy(How = How.Id, Using = "jform_access")]
        public IWebElement cboAccess;
        [FindsBy(How = How.Id, Using = "jform_articletext_ifr")]
        public IWebElement frameTextArea;
        [FindsBy(How = How.Id, Using = "tinymce")]
        public IWebElement txtTextArea;

        [FindsBy(How = How.CssSelector, Using = ".btn.js-stools-btn-filter")]
        public IWebElement btnSearchTool;
        [FindsBy(How = How.CssSelector, Using = ".btn.js-stools-btn-clear")]
        public IWebElement btnClear;
        [FindsBy(How = How.Id, Using = "filter_search")]
        public IWebElement txtFilterSearch;


        //filter
        [FindsBy(How = How.Id, Using = "filter_published")]
        public IWebElement cboStatusFilter;
        [FindsBy(How = How.Id, Using = "filter_access")]
        public IWebElement cboAccessFilter;
        [FindsBy(How = How.Id, Using = "filter_author_id")]
        public IWebElement cboAthorFilter;

        public void addNewArticle(string title, string categoryItem, string statusItem = null, string accessItem = null, string description = null)
        {
            clickControl(btnNew);
            fillArticleInformation(title, categoryItem, statusItem, accessItem, description);
            clickControl(btnSaveAndClose);
        }
        public void editArticle(string title, string categoryItem, string statusItem = null, string accessItem = null, string description = null)
        {
            clickControl(btnEdit);
            fillArticleInformation(title, categoryItem, statusItem, accessItem, description);
            clickControl(btnSaveAndClose);
        }
        public void fillArticleInformation(string title, string categoryItem, string statusItem = null, string accessItem = null, string description = null)
        {
            enterText(txtTitle, title);
            selectDropDown(cboCategory, categoryItem);
            selectDropDown(cboStatus, statusItem);
            selectDropDown(cboAccess, accessItem);
            if (description != null)
            {
                switchToFrame(frameTextArea);
                enterText(txtTextArea, description);
                switchToDefault();
            }
        }

        public void checkArticleDisplay(string title, string categoryitem, string status = null)
        {
            searchByTitle(txtFilterSearch, title);
            int rowcounts = driver.FindElements(By.XPath("//table[@id='articlelist']//tbody/tr")).Count;
            //int colcounts = driver.findelements(by.xpath("//table[@id='articlelist']//thead/tr/th")).count;
            for (int i = 1; i <= rowcounts; i++)
            {
                Assert.IsTrue(driver.FindElement(By.XPath("//table[@id='articlelist']//tbody/tr[" + i + "]/td[4]//a[normalize-space()=\"" + title + "\"]")).Displayed);
                Assert.IsTrue(driver.FindElement(By.XPath("//table[@id='articlelist']//tbody/tr[" + i + "]/td[4]//div[normalize-space()='category: " + categoryitem + "']")).Displayed);

                if (status != null)
                {
                    switch (status)
                    {
                        case "published":
                            Assert.IsTrue(driver.FindElement(By.XPath("//table[@id='articlelist']//tbody/tr[" + i + "]/td[3]//span[@class='icon-publish']")).Displayed);
                            break;
                        case "unpublished":
                            Assert.IsTrue(driver.FindElement(By.XPath("//table[@id='articlelist']//tbody/tr[" + i + "]/td[3]//span[@class='icon-unpublish']")).Displayed);
                            break;
                        case "archived":
                            Assert.IsTrue(driver.FindElement(By.XPath("//table[@id='articlelist']//tbody/tr[" + i + "]/td[3]//span[@class='icon-archive']")).Displayed);
                            break;
                    }
                }
            }
            clickControl(btnClear);
        }
    }
}

