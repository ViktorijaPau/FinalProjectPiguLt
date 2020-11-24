using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Baigiamasis.Page
{
   public class PiguLtBasePage
    {
        private const string pageAddress = "https://pigu.lt/lt/";
        private const string loginButtonText = "Prisijungti";
        private IWebElement VisitorLoginButton => driver.FindElement(By.CssSelector("#fixedHeaderContainer > div > div > div.header-bottom > ul > li.visitor-login.has-submenu.guide-item > a > div > span"));
        private IWebElement EmailInputField => driver.FindElement(By.Name("email"));
        private IWebElement PasswordInputField => driver.FindElement(By.Name("password"));
        private IWebElement LoginButton => driver.FindElement(By.Name("login"));
        private IWebElement VisitorLoginSubmenu => driver.FindElement(By.CssSelector("#fixedHeaderContainer > div > div > div.header-bottom > ul > li.visitor-login.has-submenu.guide-item"));
        private IWebElement LogOutText => driver.FindElement(By.CssSelector("#fixedHeaderContainer > div > div > div.header-bottom > ul > li.visitor-login.has-submenu.guide-item > div > ul > li:nth-child(7) > a"));

        protected static IWebDriver driver;

        public PiguLtBasePage(IWebDriver webDriver)
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

        public PiguLtBasePage NavigateToDefaultPage()
        {
            if (driver.Url != pageAddress)
            {
                driver.Url = pageAddress;
            }
            return this;
        }

        public PiguLtBasePage PressVisitorLogin()
        {
            VisitorLoginButton.Click();
            return this;
        }

        public PiguLtBasePage InputEmail(string email)
        {
            EmailInputField.Clear();
            EmailInputField.SendKeys(email);
            return this;
        }

        public PiguLtBasePage InputPassword(string password)
        {
            PasswordInputField.Clear();
            PasswordInputField.SendKeys(password);
            return this;
        }

        public PiguLtBasePage HitLoginButton()
        {
            LoginButton.Click();
            return this;
        }

        public PiguLtBasePage PerformLogin(string email, string password)
        {
            NavigateToDefaultPage();
            if (VisitorLoginButton.Text == loginButtonText)
            {
                PressVisitorLogin();
                InputEmail(email);
                InputPassword(password);
                HitLoginButton();
            }
            return this;
        }

        public PiguLtBasePage LogOut()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(VisitorLoginSubmenu).Perform();
            LogOutText.Click();
            return this;
        }
    }
}
    