﻿using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace POMJoomlaTest.PageObjects
{
   public class CommonPage
    {
        public IWebDriver driver;
        public string title;
        public CommonPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".btn.hasTooltip")]
        public IWebElement btnSearch;
        [FindsBy(How = How.XPath, Using = "//div[@class='alert alert-success']/div[@class='alert-message']")]
        public IWebElement successMessage;

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
        public void enterText(IWebElement element,string text)
        {
            element.Clear();
            element.Click();
            element.SendKeys(text);
        }
        public void selectDropDown(IWebElement element, string item)
        {
            if (item != null)
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].style.display = 'block';", element);
                new SelectElement(element).SelectByText(item);
            }            
        }
        public void selectByTitle(string title)
        {
            driver.FindElement(By.XPath("//a[normalize-space()=\"" + title + "\"]/ancestor::tr//input[@type='checkbox']")).Click();
        }
        public void searchByTitle(IWebElement element, string title)
        {
            enterText(element, title);
            clickControl(btnSearch);

        }
        public void verifyControlMessage(IWebElement element, string message)
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
