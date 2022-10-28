using Ecommerce.Shared.Domain;
using Ecommerce.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace E_Commerce.UI.Controllers
{
    public class ProductController : Controller
    {
        public ProductController(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        [HttpGet]
        public IActionResult Products()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UploadedFile(ProductModel obj)
        {
            ProductDomain productDomain = new ProductDomain();
            if(obj!= null)
            {
                productDomain.MainImage = Image(obj.MainImage);
                productDomain.OtherImages = "";
                for(int i=0; i < obj.OtherImages.Length; i++)
                {
                    productDomain.OtherImages = productDomain.OtherImages + "," + Image(obj.OtherImages[i]);
                }
            }
           return Ok(productDomain);
           
        }
        string Image (IFormFile img)
        {
            string uniqueFileName = "";

            if (img != null)
            {
                string uploadsFolder = Path.Combine(WebHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + img.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    img.CopyTo(fileStream);
                }
            }
            return uniqueFileName;

        }
    }
}
