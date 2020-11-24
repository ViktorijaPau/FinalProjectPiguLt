using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumWrapper = SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Interactions;

using System.Threading;


namespace Baigiamasis.Page
{
    public class PiguLtLoginPage : BasePage
    {
        private const string pageAddress = "https://pigu.lt/lt/";
        private IWebElement visitorLoginButton => driver.FindElement(By.CssSelector("#fixedHeaderContainer > div > div > div.header-bottom > ul > li.visitor-login.has-submenu.guide-item > a > div > span"));
        private IWebElement emailInputField => driver.FindElement(By.Name("email"));
        private IWebElement passwordInputField => driver.FindElement(By.Name("password"));
        private IWebElement loginButton => driver.FindElement(By.Name("login"));
        private IWebElement visitorLoginSubmenu => driver.FindElement(By.CssSelector("#fixedHeaderContainer > div > div > div.header-bottom > ul > li.visitor-login.has-submenu.guide-item"));
        private IWebElement logOutText => driver.FindElement(By.CssSelector("#fixedHeaderContainer > div > div > div.header-bottom > ul > li.visitor-login.has-submenu.guide-item > div > ul > li:nth-child(7) > a"));
        private IWebElement resultText => driver.FindElement(By.CssSelector("#editMyInfo > div.user-tab-col.tac > div > div.user-name"));


        public PiguLtLoginPage(IWebDriver webDriver) : base(webDriver)
        {
            
        }
        public PiguLtLoginPage NavigateToDefaultPage()
        {
            if (driver.Url != pageAddress)
            {
                driver.Url = pageAddress;
            }
            return this;
        }
        public PiguLtLoginPage PressVisitorLogin()
        {
            visitorLoginButton.Click();
            return this;
        }
       
        public PiguLtLoginPage InputEmail(string email)
        {
            emailInputField.Clear();
            emailInputField.SendKeys(email);
            return this;
        }

        public PiguLtLoginPage InputPassword(string password)
        {
            passwordInputField.Clear();
            passwordInputField.SendKeys(password);
            return this;
        }
        public PiguLtLoginPage HitLoginButton()
        {
            loginButton.Click();
            return this;
        }
        public PiguLtLoginPage VerifyLogin(string userName)
        {
            Assert.IsTrue(resultText.Text.Contains(userName));
            return this;
        }
        public PiguLtLoginPage LogOut()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(visitorLoginSubmenu).Perform();
            action.MoveToElement(logOutText).Click();
            return this;
        }
    }

}

