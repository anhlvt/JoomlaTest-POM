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
   public class CommonPage
    {
        private IWebDriver driver;
        public string title;
        public CommonPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }        
        public void switchToFrame(IWebElement frame)
        {
            driver.SwitchTo().DefaultContent();
            driver.SwitchTo().Frame(frame);
        }
        public void switchToDefault()
        {
            driver.SwitchTo().DefaultContent();
        }
        public void clickControl(IWebElement element)
        {
            element.Click();
        }
        public void enterTextBox(IWebElement element,string text)
        {
            element.Clear();
            element.Click();
            element.SendKeys(text);
        }
        public void selectDropDown(IWebElement element, string item)
        {

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].style.display = 'block';",element) ;
            new SelectElement(element).SelectByText(item);
        }
        public void verifySuccessMessage(IWebElement element, string message)
        {
            try
            {
                Assert.IsTrue(element.Text.Equals(message));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }        
    }
}
