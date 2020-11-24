using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Baigiamasis.Page
{
    public class WishList : PiguLtBasePage
    {
        private const string pageAddress = "https://pigu.lt/lt/u/wishlist";
        private IWebElement SearchField => driver.FindElement(By.Id("searchInput"));
        private IWebElement SearchButton => driver.FindElement(By.CssSelector("#searchRow > button"));
        private IWebElement AddToWishListButton => driver.FindElement(By.CssSelector(".btn > span"));
        private IWebElement ClosePopUpButton => driver.FindElement(By.Id("close"));
        private IWebElement WishListMenuButton => driver.FindElement(By.CssSelector("#wishlist > a"));
        private IWebElement ItemContainerText => driver.FindElement(By.CssSelector(".product-list-item > div > div > p > a"));
        private IWebElement ItemButton => driver.FindElement(By.CssSelector(".product-list-item > div > div > a"));

        public WishList(IWebDriver webDriver) : base(webDriver)
        {

        }

        public WishList NavigateToPage()
        {
            if (driver.Url != pageAddress)
            {
                driver.Url = pageAddress;
            }
            return this;
        }
        
        public WishList InputItemToSearch(string itemToSearchFor)
        {
            SearchField.Clear();
            SearchField.SendKeys(itemToSearchFor);
            return this;
        }

        public WishList PressSearchButton()
        {
            SearchButton.Click();
            return this;
        }

        public WishList OpenItemDescription()
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(ItemButton).Click().Perform();
            return this;
        }

        public WishList AddItemToWishList()
        {
            AddToWishListButton.Click();
            return this;
        }

        public WishList ClosePopUp()
        {
            ClosePopUpButton.Click();
            return this;
        }

        public WishList OpenWishList()
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(WishListMenuButton).Click().Perform();
            WishListMenuButton.Click();
            return this;
        }

        public WishList VerifyItemAddedToWishList(string itemName)
        {
            Assert.IsTrue(ItemContainerText.Text.Contains(itemName));
            return this;
        }

        public WishList RemoveItemFromWishList()
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(ItemButton).Click().Perform();
            AddToWishListButton.Click();
            return this;
        }

        public WishList VerifyItemIsRemoved(string buttonText)
        {
            Assert.IsTrue(AddToWishListButton.Text.Contains(buttonText));
            return this;
        }
    }
}


