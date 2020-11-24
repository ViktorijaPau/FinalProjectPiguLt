using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Baigiamasis.Page
{
    public class CartPage:PiguLtBasePage
    {
        private const string pageAddress = "https://pigu.lt/lt/cart";
        private IReadOnlyCollection<IWebElement> DisplayedGoodsList => driver.FindElements(By.CssSelector(".product-list-item.tag-top"));
        private IWebElement AddToCartButton => driver.FindElement(By.CssSelector("#productPage > section:nth-child(3) > div.site-block > div.clearfix.detailed-product-top > div.product-info-options > div.add-product-box.sticked > div.add-to-cart-block > button"));
        private IWebElement BuyButton => driver.FindElement(By.Id("buy"));
        private IWebElement BasketProductName => driver.FindElement(By.CssSelector(".product-name"));
        private IWebElement IncreaseButton => driver.FindElement(By.CssSelector(".inc"));
        private IWebElement SingleItemPriceBox => driver.FindElement(By.CssSelector(".price_cell"));
        private IWebElement ItemsAmountInCartBox => driver.FindElement(By.CssSelector(".input-small"));
        private IWebElement TotalAmountToPayPerItemLineBox => driver.FindElement(By.CssSelector(".price.notranslate"));
        private IWebElement CartWidget => driver.FindElement(By.CssSelector("#cartWidget"));
        private IWebElement RemoveItemBox => driver.FindElement(By.CssSelector(".icon-remove"));
        private IWebElement CartItemCount => driver.FindElement(By.Id("spanText"));

        private decimal singleItemPrice => Convert.ToDecimal(SingleItemPriceBox.Text.Trim(' ', '€'));
        private int itemsAmountInCart => Convert.ToInt32(ItemsAmountInCartBox.GetAttribute("value"));
        private decimal totalAmountPerItemLine => Convert.ToDecimal(TotalAmountToPayPerItemLineBox.Text.Trim(' ', '€'));

        private string ProductName { get; set; }

        public CartPage(IWebDriver webDriver) : base(webDriver)
        {

        }

        public CartPage NavigateToPage()
        {
            if (driver.Url != pageAddress)
            {
                driver.Url = pageAddress;
            }
            return this;
        }

        public CartPage ClickFirstAvailableOption()
        { 
            DisplayedGoodsList.First().Click();
            return this;
        }

        public CartPage AddItemToCart()
        {
            ProductName = driver.FindElement(By.CssSelector("#productPage > section:nth-child(3) > div.site-block > h1")).Text;
            AddToCartButton.Click();
            return this;
        }

        public CartPage ProceedToBuy()
        {
            BuyButton.Click();
            return this;
        }

        public CartPage VerifyItemIsInTheCart()
        {
            Assert.AreEqual(ProductName, BasketProductName.Text);
            return this;
        }

        public CartPage IncreaseItemAmountInCart()
        {
            IncreaseButton.Click();
            return this;
        }

        public CartPage VerifyTotalItemsAndPrice()
        {
            System.Threading.Thread.Sleep(2000);
            Assert.AreEqual(totalAmountPerItemLine, singleItemPrice * itemsAmountInCart);
            return this;
        }

        public CartPage RemoveItemFromCart()
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(CartWidget);
            actions.MoveToElement(RemoveItemBox).Click().Perform();
            return this;
        }

        public CartPage AcceptAlert()
        {
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            return this;
        }

        public CartPage VerifyCartEmpty()
        {
            Thread.Sleep(2000);
            Assert.IsTrue(CartItemCount.Text == "0");
            return this;
        }
    }
}
