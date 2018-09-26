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

namespace POMJoomlaTest
{
    public class TestBase
    {
        private IWebDriver driver;
        public TestBase(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Id, Using = "mod-login-username")]
        private IWebElement txtUserName;

        public void enterTextbox(string text)
        {
            txtUserName.SendKeys(text);
        }

    }
}
