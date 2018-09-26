using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;

namespace POMJoomlaTest.PageObjects
{
    public class HomePage
    {
        public IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;            
        }
                
        By contentBar = By.LinkText("Content");
        By articlesBar = By.LinkText("Articles");        

        public void goToArticlePage()
        {
            driver.FindElement(contentBar).Click();
            driver.FindElement(articlesBar).Click();            
        }

    }
}
