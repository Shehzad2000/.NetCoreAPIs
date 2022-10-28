using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.UI.Controllers
{
    public class ProductDetailsController : Controller
    {
        [HttpPost]
        public IActionResult ProductDetail(int ID)
        {
            return View(ID);
        }

    }
}
