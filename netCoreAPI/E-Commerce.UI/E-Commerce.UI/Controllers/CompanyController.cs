using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.UI.Controllers
{
    public class CompanyController : Controller
    {
        public IActionResult Company()
        {
            return View();
        }
    }
}
