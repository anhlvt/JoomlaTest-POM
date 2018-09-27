using OpenQA.Selenium;
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
        [FindsBy(How = How.LinkText, Using = "Media")]
        public IWebElement linkMedia;

        public void goToArticlePage()
        {
            clickControl(barContent);
            clickControl(barArticles);
        }
        public void goToMediaPage()
        {
            clickControl(linkMedia);
        }

    }
}
