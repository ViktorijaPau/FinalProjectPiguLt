using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumWrapper = SeleniumExtras.WaitHelpers;

namespace Baigiamasis.Page
{
    public class PiguLtWishList : BasePage
    {
        private const string pageAddress = "https://pigu.lt/lt/u/wishlist";
        private IWebElement searchField => driver.FindElement(By.Id("searchInput"));
        private IWebElement searchButton => driver.FindElement(By.CssSelector("#searchRow > button"));


        private IWebElement addToWishListButton => driver.FindElement(By.CssSelector(".btn > span"));
        private IWebElement closePopUpButton => driver.FindElement(By.Id("close"));
        private IWebElement wishListMenuButton => driver.FindElement(By.CssSelector("#wishlist > a"));
        private IWebElement itemContainerText => driver.FindElement(By.CssSelector(".product-list-item > div > div > p > a"));

        private IWebElement itemButton => driver.FindElement(By.CssSelector(".product-list-item > div > div > a"));


        public PiguLtWishList(IWebDriver webDriver) : base(webDriver)
        {

        }
        public PiguLtWishList NavigateToDefaultPage()
        {
            if (driver.Url != pageAddress)
            {
                driver.Url = pageAddress;
            }
            return this;
        }
        public PiguLtWishList InputItemToSearch(string itemToSearchFor)
        {
            searchField.Clear();
            searchField.SendKeys(itemToSearchFor);
            return this;
        }
        public PiguLtWishList PressSearchButton()
        {
            searchButton.Click();
            return this;
        }
        public PiguLtWishList OpenItemDescription()
        {

            GetWait();

            Actions actions = new Actions(driver);

            actions.MoveToElement(itemButton).Click().Perform();

            GetWait();
            return this;
        }
        public PiguLtWishList AddItemToWishList()
        {

            addToWishListButton.Click();
            return this;
        }
        public PiguLtWishList ClosePopUp()
        {
            closePopUpButton.Click();
            return this;
        }
        public PiguLtWishList OpenWishList()
        {
            GetWait();
            Actions actions = new Actions(driver);

            actions.MoveToElement(wishListMenuButton).Click().Perform();
            wishListMenuButton.Click();
            return this;
        }
        public PiguLtWishList VerifyItemAddedToWishList(string itemName)
        {
            GetWait();
            Assert.IsTrue(itemContainerText.Text.Contains(itemName));
            return this;
        }
        public PiguLtWishList RemoveItemFromWishList()
        {
            GetWait();

            Actions actions = new Actions(driver);

            actions.MoveToElement(itemButton).Click().Perform();

            GetWait();
            addToWishListButton.Click();

            return this;
        }
        public PiguLtWishList AssertItemIsRemoved(string buttonText)
        {
            Assert.IsTrue(addToWishListButton.Text.Contains(buttonText));
            return this;
        }



    }

}


