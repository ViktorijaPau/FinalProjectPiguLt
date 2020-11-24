using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;

namespace Baigiamasis.Page
{
    public class GlovesPage : PiguLtBasePage
    {
        private const string pageAddress = "https://pigu.lt/lt/vaistines-prekes/medicinines-prekes/pirmoji-pagalba/f/all/vienkartines-pirstines";
        private IReadOnlyCollection<IWebElement> GoodsList => driver.FindElements(By.CssSelector(".api.product-list-item.tag-top"));
        private IWebElement SelectArrangement => driver.FindElement(By.CssSelector("#leafControl > div.main-block.fr > section > div.list-controls.controls-top.clearfix > div > div.fr > a"));
        private IWebElement CheapestFirst => driver.FindElement(By.XPath("/html/body/div[5]/div/ul/li[2]"));
        
        public GlovesPage(IWebDriver webDriver) : base(webDriver)
        {

        }

        public GlovesPage NavigateToPage()
        {
            if (driver.Url != pageAddress)
            {
                driver.Url = pageAddress;
            }
            return this;
        }

        public GlovesPage ClickSmallestFirstButton()
        {
            
            Actions actions = new Actions(driver);
            actions.MoveToElement(SelectArrangement).Click().Perform();
            CheapestFirst.Click();
            System.Threading.Thread.Sleep(2000);
            return this;
        }

        public GlovesPage VerifyFirstPriceIsSmallest()
        {
            IWebElement firstInList = GoodsList.First();
            string firstInListText = firstInList.FindElement(By.CssSelector(".price.notranslate")).Text;
            double firstInListValue = PriceTextToPriceValue(firstInListText); 

            foreach (IWebElement element in GoodsList)
            {
                string priceText = element.FindElement(By.CssSelector(".price.notranslate")).Text;
                double priceValue = PriceTextToPriceValue(priceText);
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
