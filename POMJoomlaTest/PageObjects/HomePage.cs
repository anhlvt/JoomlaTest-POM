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
   public class HomePage : CommonPage
    {
        private IWebDriver driver;
        public HomePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.LinkText, Using = "Content")]
        public IWebElement barContent;
        [FindsBy(How = How.LinkText, Using = "Articles")]
        public IWebElement barArticles;                

        public void goToArticlePage()
        {
            clickControl(barContent);
            clickControl(barArticles);
        }

    }
}
