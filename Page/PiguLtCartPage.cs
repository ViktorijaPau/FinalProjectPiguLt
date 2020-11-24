using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baigiamasis.Page
{
    public class PiguLtCartPage:BasePage
    {
        private const string pageAddress = "https://pigu.lt/lt/cart";
        private IReadOnlyCollection<IWebElement> DisplayedGoodsList => driver.FindElements(By.CssSelector(".product-list-item.tag-top"));
        private IWebElement AddToCartButton => driver.FindElement(By.CssSelector("#productPage > section:nth-child(3) > div.site-block > div.clearfix.detailed-product-top > div.product-info-options > div.add-product-box.sticked > div.add-to-cart-block > button"));
        private IWebElement BuyButton => driver.FindElement(By.Id("buy"));
        private IWebElement BasketProductName => driver.FindElement(By.CssSelector(".product-name"));

        private string ProductName { get; set; }

        public PiguLtCartPage(IWebDriver webDriver) : base(webDriver)
        {

        }
        public PiguLtCartPage NavigateToDefaultPage()
        {
            if (driver.Url != pageAddress)
            {
                driver.Url = pageAddress;
            }
            return this;
        }
        public PiguLtCartPage ClickFirstAvalableOption()
        {
            
            DisplayedGoodsList.First().Click();

            return this;
        }
        public PiguLtCartPage AddItemToCart()
        {
            ProductName = driver.FindElement(By.CssSelector("#productPage > section:nth-child(3) > div.site-block > h1")).Text;
            AddToCartButton.Click();
            return this;
        }
        public PiguLtCartPage ProceedToBuy()
        {
            BuyButton.Click();
            return this;
        }
        public PiguLtCartPage VerifyItemIsInTheCart()
        {
            Assert.AreEqual(ProductName, BasketProductName.Text);
            return this;
        }
    }
}
