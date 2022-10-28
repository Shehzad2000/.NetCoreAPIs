using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.UI.Controllers
{
    public class CartController : Controller
    {
        [HttpGet]
        public IActionResult CartView()
        {
            return View();
        }
    }
}
