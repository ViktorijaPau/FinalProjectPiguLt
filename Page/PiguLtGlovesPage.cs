using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;
using SeleniumWrapper = SeleniumExtras.WaitHelpers;

namespace Baigiamasis.Page
{
    public class PiguLtGlovesPage : BasePage
    {
        private const string pageAddress = "https://pigu.lt/lt/vaistines-prekes/medicinines-prekes/pirmoji-pagalba/f/all/vienkartines-pirstines";
        private const string cheapestFirstLabel = "Pigiausios viršuje";
        
        private IReadOnlyCollection<IWebElement> goodsList => driver.FindElements(By.CssSelector(".api.product-list-item.tag-top"));
        private IWebElement availabilityStatus => driver.FindElement(By.XPath("//*[@id=\"productPage\"]/section[1]/div[1]/div[3]/div[3]/div[7]/div[4]/div/div/text()"));
        private IWebElement selectArrangement => driver.FindElement(By.CssSelector("#leafControl > div.main-block.fr > section > div.list-controls.controls-top.clearfix > div > div.fr > a"));
        private IWebElement cheapesFirst => driver.FindElement(By.XPath("/html/body/div[5]/div/ul/li[2]"));
        private IWebElement addToCartButton => driver.FindElement(By.CssSelector("#productPage > section:nth-child(3) > div.site-block > div.clearfix.detailed-product-top > div.product-info-options > div.add-product-box.sticked > div.add-to-cart-block > button"));
        
        
        public PiguLtGlovesPage(IWebDriver webDriver) : base(webDriver)
        {

        }
        public PiguLtGlovesPage NavigateToDefaultPage()
        {
            if (driver.Url != pageAddress)
            {
                driver.Url = pageAddress;
            }
            return this;
        }

        public PiguLtGlovesPage ClickSmallestFirstButton()
        {
            GetWait();
            Actions actions = new Actions(driver);

            actions.MoveToElement(selectArrangement).Click().Perform();
            cheapesFirst.Click();
            GetWait().Until(ExpectedConditions.TextToBePresentInElement(selectArrangement, cheapestFirstLabel));
            System.Threading.Thread.Sleep(5000);
            return this;
        }

        public PiguLtGlovesPage CheckIfFirstPriceIsSmallest()
        {
            IWebElement firstInList = goodsList.First();
            string firstInListText = firstInList.FindElement(By.CssSelector(".price.notranslate")).Text;
            double firstInListValue = PriceTextToPriceValue(firstInListText);
            

            foreach (IWebElement element in goodsList)
            {
                var priceText = element.FindElement(By.CssSelector(".price.notranslate")).Text;
                var priceValue = PriceTextToPriceValue(priceText);
                Assert.GreaterOrEqual(priceValue, firstInListValue);
            }
            return this;
        }

        private double PriceTextToPriceValue(string price)
        {
            string priceTrimmed = price.Trim('€', ' ');
            double priceValue = double.Parse(priceTrimmed);
            return priceValue;
        }
        
        
    }

}
