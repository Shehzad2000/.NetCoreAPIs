using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.UI.Controllers
{
    public class CategoryController : Controller
    {
        [HttpGet]
        public IActionResult Category()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Category1()
        {
            return View();
        }
    }
}
