﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace POMJoomlaTest.PageObjects
{
    public class LoginPage : CommonPage
    {
        private IWebDriver driver;
        public LoginPage(IWebDriver driver) : base(driver)
        {          
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "mod-login-username")]
        public IWebElement txtUserName;
        [FindsBy(How = How.Id, Using = "mod-login-password")]
        public IWebElement txtPassword;
        [FindsBy(How = How.CssSelector, Using = ".btn.login-button")]
        public IWebElement btnLogin;

        public void goToWebPage()
        {
            //driver.Url = ConfigurationManager.AppSettings["URL"];
            driver.Navigate().GoToUrl("http://192.168.190.247/joomlatest/administrator/index.php");
        }
        public void login(string username, string password)
        {
            enterText(txtUserName, username);
            enterText(txtPassword, password);
            clickControl(btnLogin);
        }

    }
}
