using Baigiamasis.Drivers;
using Baigiamasis.Page;
using Baigiamasis.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace Baigiamasis.Test
{
    public class BaseTest
    {
        public IWebDriver driver;
        public static LoginPage loginPage;
        public static WishList wishListPage;
        public static GlovesPage glovesPage;
        public static CartPage cartPage;

        [OneTimeSetUp]
        public void SetUp()
        {
            driver = CustomDriver.GetChromeDriver();
            loginPage = new LoginPage(driver);
            wishListPage = new WishList(driver);
            glovesPage = new GlovesPage(driver);
            cartPage = new CartPage(driver);
        }

        [TearDown]
        public void TakeScreenshot()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                MyScreenshot.MakeScreenshot(driver);
            }
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}