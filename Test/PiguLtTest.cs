using NUnit.Framework;

namespace Baigiamasis.Test
{
    [NonParallelizable]
    public class PiguLtTest : BaseTest
    {
        [Test, Order(1)]
        [TestCase("v.laurinaviciute@gmail.com", "password1","TestUser", TestName = "Login")]
        public void TestLogin(string email, string password, string userName)
        {
            loginPage.PerformLogin(email, password);
            loginPage.VerifyLogin(userName);
        }

        [Test, Order(2)]
        [TestCase("v.laurinaviciute@gmail.com", "password1","10913 LEGO", TestName = "Add item to wishlist")]
        public void TestAddGoodsToWishList(string email, string password,  string itemName)
        {
            wishListPage.PerformLogin(email, password);
            wishListPage.InputItemToSearch(itemName)
                   .PressSearchButton()
                   .OpenItemDescription()
                   .AddItemToWishList()
                   .ClosePopUp()
                   .OpenWishList()
                   .VerifyItemAddedToWishList(itemName);
        }

        [Test,Order(3)]
        [TestCase("v.laurinaviciute@gmail.com", "password1","Įtraukti į norų sąrašą", TestName = "Remove item from wishlist")]
        public void TestRemoveItemFromWishList(string email, string password,string buttonText)
        {
            wishListPage.PerformLogin(email, password);
            wishListPage.NavigateToPage()
                .RemoveItemFromWishList()
                .ClosePopUp()
                .VerifyItemIsRemoved(buttonText);
        }

        [Test,Order(4)]
        [TestCase(TestName = "Cheapest item first")]    
        public void TestTheCheapestGloves()
        {
            glovesPage.NavigateToPage()
                .ClickSmallestFirstButton()
                .VerifyFirstPriceIsSmallest();
        }

        [Test, Order(5)]
        [TestCase("v.laurinaviciute@gmail.com", "password1", TestName = "Add Item To Cart")]
        public void TestItemAddedToCart(string email, string password)
        {
            cartPage.PerformLogin(email, password);
            cartPage.NavigateToPage()
                .ClickFirstAvailableOption()
                .AddItemToCart()
                .ProceedToBuy()
                .VerifyItemIsInTheCart();
        }

        [Test, Order(6)]
        [TestCase("v.laurinaviciute@gmail.com", "password1", TestName = "Total price per item line in cart")]
        public void TestTotaAmountPerItemLine(string email, string password)
        {
            cartPage.PerformLogin(email, password);
            cartPage.NavigateToPage()
                .IncreaseItemAmountInCart()
                .VerifyTotalItemsAndPrice();
        }

        [Test, Order (7)]
        [TestCase ("v.laurinaviciute@gmail.com", "password1", TestName = "Remove item from cart")]
        public void TestItemRemovedFromCart(string email, string password)
        {
            cartPage.PerformLogin(email, password);
            cartPage.RemoveItemFromCart()
                .AcceptAlert()
                .VerifyCartEmpty();
        }

        [Test,Order (8)]
        [TestCase("v.laurinaviciute@gmail.com", "password1", TestName = "Logout")]
        public void TestLogout(string email, string password)
        {
            loginPage.PerformLogin(email, password)
                .LogOut();
            loginPage.VerifyLogout();
        }
    }
}