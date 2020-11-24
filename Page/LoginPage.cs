using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace Baigiamasis.Page
{
    public class LoginPage : PiguLtBasePage
    {
        private const string loginWidgetText = "Prisijungti";
        private IWebElement ResultText => driver.FindElement(By.CssSelector("#editMyInfo > div.user-tab-col.tac > div > div.user-name"));
        private IWebElement LoginButtonTextBox => driver.FindElement(By.CssSelector("#fixedHeaderContainer > div > div > div.header-bottom > ul > li.visitor-login.has-submenu.guide-item > a > div > span"));
        

        public LoginPage(IWebDriver webDriver) : base(webDriver)
        {
            
        }

        public LoginPage VerifyLogin(string userName)
        {
            Assert.IsTrue(ResultText.Text.Contains(userName));
            return this;
        }

        public LoginPage VerifyLogout()
        {
            Assert.AreEqual(loginWidgetText, LoginButtonTextBox.Text);
            return this;
        }
    
    }
}

