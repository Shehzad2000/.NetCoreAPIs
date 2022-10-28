using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.UI.Controllers
{
    public class BrandController : Controller
    {
        [HttpGet]
        public IActionResult Brands()
        {
            return View();
        }
    }
}
