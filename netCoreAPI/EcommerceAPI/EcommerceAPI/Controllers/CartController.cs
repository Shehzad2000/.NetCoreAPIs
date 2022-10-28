using Ecommerce.Core.Providers;
using Ecommerce.Shared.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartProvider cartProvider;

        public CartController(ICartProvider cartProvider)
        {
            this.cartProvider = cartProvider;
        }
        [HttpPost, Route("AddProductToCart")]
        public async Task<IActionResult> AddProduct(CartDomain cartDomain)
            => Ok(await cartProvider.AddProductToCart(cartDomain));
        [HttpPost, Route("AddPlusOneToQuantity")]
        public async Task<IActionResult> Addition(CartDomain cartDomain)
            => Ok(await cartProvider.UpdateProduct(cartDomain.CartID,true));
        [HttpPost, Route("RemoveOneItemFromCart")]
        public async Task<IActionResult> Removeitem(CartDomain cartDomain)
            => Ok(await cartProvider.UpdateProduct(cartDomain.CartID,false));
        [HttpPost, Route("RemoveCart")]
        public async Task<IActionResult> DeleteCart(CartDomain cartDomain)
            => Ok(await cartProvider.DeleteProduct(cartDomain.CartID));
        [HttpGet, Route("LoadCartProducts")]
        public async Task<IActionResult> LoadData()=>Ok(await cartProvider.GetCartProducts());
    }
}
