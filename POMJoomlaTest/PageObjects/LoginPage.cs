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
    public class LoginPage:TestBase
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
            : base(driver)
        {          
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "mod-login-username")]
        private IWebElement txtUserName;
        [FindsBy(How = How.CssSelector, Using = "mod-login-password")]
        private IWebElement txtPassword;
        [FindsBy(How = How.CssSelector, Using = ".btn btn-primary btn-block btn-large login-button")]
        private IWebElement btnLogin; 

        public void login(string username, string password)
        {
            txtUserName.SendKeys(username);
            txtPassword.SendKeys(password);
            btnLogin.Click();
        }
    }
}
