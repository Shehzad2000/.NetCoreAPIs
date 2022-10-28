using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public UserController(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        public IActionResult Users()
        {
            return View();
        }
        [HttpPost,Route("UploadedFile")]
        public JsonResult UploadFile(IFormFile img)
        {
            string uniqueFileName = "";

            if (img != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + img.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    img.CopyTo(fileStream);
                }
            }
            return Json(uniqueFileName);
        }
    }
}
