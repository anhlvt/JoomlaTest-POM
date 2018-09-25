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
    class LoginPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;            
        }

        By usernameTxt = By.Id("mod-login-username");
        By passwordTxt = By.Id("mod-login-password");
        By loginBtn = By.ClassName("login-button");
       
        public void goToPage()
        {
            driver.Navigate().GoToUrl("http://192.168.190.247/joomlatest/administrator/index.php");
        }

        public void login(string username, string password)
        {
            driver.FindElement(usernameTxt).SendKeys(username);
            driver.FindElement(passwordTxt).SendKeys(username);
            driver.FindElement(loginBtn).Click();            
        }
    }
}
