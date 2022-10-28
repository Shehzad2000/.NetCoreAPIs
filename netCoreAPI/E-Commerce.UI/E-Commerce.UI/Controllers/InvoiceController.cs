using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.UI.Controllers
{
    public class InvoiceController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
