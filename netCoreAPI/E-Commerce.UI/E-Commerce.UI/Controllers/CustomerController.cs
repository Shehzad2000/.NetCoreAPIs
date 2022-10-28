using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.UI.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet]
        public IActionResult Customer()
        {
            return View();
        }
    }
}
