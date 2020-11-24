using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Baigiamasis.Page
{
   public class BasePage
    {
        protected static IWebDriver driver;

        public BasePage(IWebDriver webDriver)
        {
            driver = webDriver;
        }
        public WebDriverWait GetWait(int seconds = 5)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            return wait;
        }

        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}
    