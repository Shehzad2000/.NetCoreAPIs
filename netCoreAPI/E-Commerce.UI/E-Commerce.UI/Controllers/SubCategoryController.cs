using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.UI.Controllers
{
    public class SubCategoryController : Controller
    {
        [HttpGet]
        public IActionResult SubCategory()
        {
            return View();
        }
    }
}
