using Baigiamasis.Page;
using NUnit.Framework;

namespace Baigiamasis.Test
{
    [NonParallelizable]
    public class PiguLtTest : BaseTest
    {

        [Test, Order(1)]
        [TestCase("v.laurinaviciute@gmail.com", "password1","TestUser", TestName = "Login Test")]
        public void TestLogin(string email, string password, string userName)
        {
            loginPage.NavigateToDefaultPage()
                 .PressVisitorLogin()
                 .InputEmail(email)
                 .InputPassword(password)
                 .HitLoginButton()
                 .VerifyLogin(userName);
                 
        }

        [Test, Order(2)]
        [TestCase("10913 LEGO", TestName = "Add item to wishlist")]
        //[TestCase("10917 LEGO", TestName = "Add item to wishlist 2 " )]
        public void AddGoodstoWishList( string itemName)
        {
            wishListPage.InputItemToSearch(itemName)
                   .PressSearchButton()
                   .OpenItemDescription()
                   .AddItemToWishList()
                   .ClosePopUp()
                   .OpenWishList()
                   .VerifyItemAddedToWishList(itemName);
            
        }
        [Test,Order(3)]
        [TestCase("Įtraukti į norų sąrašą", TestName = "Remove item from wishlist")]
        public void RemoveItemFromWishList(string buttonText)
        {
            wishListPage.RemoveItemFromWishList()
                .ClosePopUp()
                .AssertItemIsRemoved(buttonText);
        }
       [Test,Order(4)]
        public void CheckTheCheapestGlovesTest()
        {
           glovesPage.NavigateToDefaultPage()
                .ClickSmallestFirstButton()
                .CheckIfFirstPriceIsSmallest();
        }
        [Test, Order(5)]
        public void CheckItemAddedToCart()
        {
            cartPage.NavigateToDefaultPage()
                .ClickFirstAvalableOption()
                .AddItemToCart()
                .ProceedToBuy()
                .VerifyItemIsInTheCart();

        }
    }
}
    

