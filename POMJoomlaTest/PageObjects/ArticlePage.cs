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
        public IWebElement btnSave ;
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

        [FindsBy(How = How.XPath, Using = "//div[@class='alert alert-success']/div[@class='alert-message']")]
        public IWebElement successMessage;        
        [FindsBy(How = How.CssSelector, Using = ".btn.js-stools-btn-filter")]
        public IWebElement btnSearchTool;


        //filter
        [FindsBy(How = How.Id, Using = "filter_published")]
        public IWebElement cboStatusFilter;        
        [FindsBy(How = How.Id, Using = "filter_access")]
        public IWebElement cboAccessFilter;
        [FindsBy(How = How.Id, Using = "filter_author_id")]
        public IWebElement cboAthorFilter;
        IWebElement title;
        [FindsBy(How = How.Id, Using = "//a[normalize-space()=\"" + title + "\"]")]
        private IWebElement iconPublish;        

        public void addNewArticle(string title, string statusItems, string categoryItems, string accessItems, string paragraph)
        {
            clickControl(btnNew);
            fillArticleInformation(title, statusItems, categoryItems, accessItems, paragraph);
            clickControl(btnSaveAndClose);
        }
        public void editArticle(string title, string statusItems, string categoryItems, string accessItems, string paragraph)
        {            
            clickControl(btnEdit);
            fillArticleInformation(title, statusItems, categoryItems, accessItems, paragraph);
            clickControl(btnSaveAndClose);
        }
        public void fillArticleInformation(string title, string statusItems,string categoryItems, string accessItems,string paragraph)
        {
            if (title != null)
            {
                enterTextBox(txtTitle, title);
            }
            if (statusItems != null)
            {
                selectDropDown(cboStatus, statusItems);
            }
            if (categoryItems!= null)
            {
                selectDropDown(cboCategory, categoryItems);
            }
            if (accessItems != null)
            {
                selectDropDown(cboAccess, accessItems);
            }
            if (paragraph != null)
            {
                switchToFrame(frameTextArea);
                enterTextBox(txtTextArea, paragraph);
                switchToDefault();
            }            
        }
        public void checkOnRecentArticle(string title)
        {
            driver.FindElement(By.XPath("//a[normalize-space()=\"" + title + "\"]/ancestor::tr//input[@type='checkbox']")).Click();
        }       
        public void checkArticleExist(string title,string categoryItem)
        {
            try
            {
                Assert.IsTrue(driver.FindElement(By.XPath("//a[normalize-space()=\"" + title + "\"]")).Displayed);
                Assert.AreEqual(driver.FindElement(By.XPath("//a[normalize-space()=\"" + title + "\"]/parent::div//div[@class='small']")).Text, "Category: " + categoryItem);
            //    Assert.IsTrue(driver.FindElement(By.XPath("//a[normalize-space()=\"" + title + "\"]/ancestor::tr//span[@class='icon-publish']")).Displayed);
            //    Assert.IsTrue(driver.FindElement(By.XPath("//a[normalize-space()=\"" + title + "\"]/ancestor::tr//span[@class='icon-unpublish']")).Displayed);
            //    Assert.IsTrue(driver.FindElement(By.XPath("//a[normalize-space()=\"" + title + "\"]/ancestor::tr//span[@class='icon-archive']")).Displayed);
            //    Assert.IsTrue(driver.FindElement(By.XPath("//a[normalize-space()=\"" + title + "\"]/ancestor::tr//span[@class='icon-trash']")).Displayed);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
