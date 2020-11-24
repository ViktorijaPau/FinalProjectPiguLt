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
        public static PiguLtLoginPage loginPage;
        public static PiguLtWishList wishListPage;
        public static PiguLtGlovesPage glovesPage;
        public static PiguLtCartPage cartPage;

        [OneTimeSetUp]

        public void SetUp()
        {
            driver = CustomDriver.GetChromeDriver();
            loginPage = new PiguLtLoginPage(driver);
            wishListPage = new PiguLtWishList(driver);
            glovesPage = new PiguLtGlovesPage(driver);
            cartPage = new PiguLtCartPage(driver);
        }
        [TearDown]
        public void TakeSchreenshot()
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

