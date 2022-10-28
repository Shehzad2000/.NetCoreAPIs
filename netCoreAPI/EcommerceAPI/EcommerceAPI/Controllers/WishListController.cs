using Ecommerce.Core.Providers;
using Ecommerce.Shared.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishListController : ControllerBase
    {
        private readonly IWishListProvider wishListProvider;

        public WishListController(IWishListProvider wishListProvider)
        {
            this.wishListProvider = wishListProvider;
        }
        [HttpPost, Route("AddProductToWishList")]
        public async Task<IActionResult> AddWishlist(WishListDomain wishList)
        => Ok(await wishListProvider.AddProductToWishList(wishList));
        [HttpPost, Route("RemoveProductFromWishlIst")]
        public async Task<IActionResult> Delete(WishListDomain wishList)
            => Ok(await wishListProvider.DeleteProductFromWishList(wishList.WishListID));
        [HttpGet, Route("GetWishListProducts")]
        public async Task<IActionResult> GetProducts(WishListDomain wishList)
            => Ok(await wishListProvider.GetWishListProduct(wishList.CustomerID));
    }
}
