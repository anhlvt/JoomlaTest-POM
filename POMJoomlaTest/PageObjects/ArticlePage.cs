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
    public class ArticlePage
    {
        private IWebDriver driver;
        public ArticlePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        //toolbar button 
        [FindsBy(How = How.Id, Using = "toolbar-new")]
        private IWebElement btnNew;
        [FindsBy(How = How.Id, Using = "toolbar-edit")]
        private IWebElement btnEdit;
        [FindsBy(How = How.Id, Using = "toolbar-publish")]
        private IWebElement btnPublish;
        [FindsBy(How = How.Id, Using = "toolbar-unpublish")]
        private IWebElement btnUnpublish;
        [FindsBy(How = How.Id, Using = "toolbar-archive")]
        private IWebElement btnArchive;        
        //information
        public By titleTxt = By.Id("jform_title");
        public By textFram = By.Id("jform_articletext_ifr");
        public By textArea = By.Id("tinymce");
        public By statusDropList = By.Id("jform_state");
        public By categorysDropList = By.Id("jform_catid");
        public By accessDropList = By.Id("jform_access");
        public By languageDropList = By.Id("jform_language");
        //save type
        public By Save = By.CssSelector("#toolbar-apply > button");
        public By SaveAndClose = By.CssSelector("#toolbar-save > button");
        public By SaveAndNew = By.CssSelector("#toolbar-save-new > button");
        public By Cancel = By.CssSelector("#toolbar-cancel > button");

        public void clickToolBarButton(By toolbar)
        {
            driver.FindElement(toolbar).Click();
        }       
        public void selectStatusDropList(string statusItems)
        {
            IWebElement hiddenWebElement = driver.FindElement(statusDropList);
            string strScript = "document.getElementById('jform_state').style.display = 'block';";
            ((IJavaScriptExecutor)driver).ExecuteScript(strScript, hiddenWebElement);
            SelectElement select = new SelectElement(driver.FindElement(statusDropList));
            select.SelectByText(statusItems);
        }
        public void selectCategoryDropList(string categoryItems)
        {
            IWebElement hiddenWebElement = driver.FindElement(categorysDropList);
            string strScript = "document.getElementById('jform_catid').style.display = 'block';";
            ((IJavaScriptExecutor)driver).ExecuteScript(strScript, hiddenWebElement);
            SelectElement select = new SelectElement(driver.FindElement(categorysDropList));
            select.SelectByText(categoryItems);
        }
        public void selectAccessDropList(string accessItems)
        {
            IWebElement hiddenWebElement = driver.FindElement(statusDropList);
            string strScript = "document.getElementById('jform_access').style.display = 'block';";
            ((IJavaScriptExecutor)driver).ExecuteScript(strScript, hiddenWebElement);
            SelectElement select = new SelectElement(driver.FindElement(statusDropList));
            select.SelectByText(accessItems);
        }        
        public void fillArticleInformation(string title, string statusItems, string categoryItems, string paragraph)
        {
            if (title != null)
            {
                driver.FindElement(titleTxt).Clear();
                driver.FindElement(titleTxt).SendKeys(title);
            }

            if (statusItems != null)
            {
                selectStatusDropList(statusItems);
            }

            if (categoryItems != null)
            {
                selectCategoryDropList(categoryItems);
            }
            
            if (paragraph != null)
            {
                driver.SwitchTo().Frame(driver.FindElement(textFram));
                driver.FindElement(textArea).Clear();
                driver.FindElement(textArea).SendKeys(paragraph);
                driver.SwitchTo().DefaultContent();
            }
        }
        public void selectSaveType(By saveType)
        {
            driver.FindElement(saveType).Click();
        }
    }
}