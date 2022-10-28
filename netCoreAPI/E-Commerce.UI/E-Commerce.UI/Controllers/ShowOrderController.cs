using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.UI.Controllers
{
    public class ShowOrderController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
