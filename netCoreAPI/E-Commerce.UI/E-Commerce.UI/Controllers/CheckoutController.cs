using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.UI.Controllers
{
    public class CheckoutController : Controller
    {
        [HttpGet]
        public IActionResult Checkouts()
        {
            return View();
        }
    }
}
