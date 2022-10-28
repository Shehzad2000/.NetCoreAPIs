using AutoMapper;
using Ecommerce.Core.Providers;
using Ecommerce.Shared.Domain;
using Ecommerce.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductProvider productProvider;

        public IMapper Mapper { get; }
        public IWebHostEnvironment WebHostEnvironment { get; }

        public ProductController(IProductProvider product, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            this.productProvider = product;
            Mapper = mapper;
            WebHostEnvironment = webHostEnvironment;
        }

        private string UploadedFile(IFormFile img)
        {
            string uniqueFileName = null;

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

        [HttpPost, Route("AddProduct")]
        public async Task<IActionResult> Register([FromForm] ProductDomain productModel)
        {
        
            string msg = await productProvider.AddProduct(productModel);
            return Ok(new { msg = msg });
        }
        [HttpPost, Route("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(ProductDomain product)
            => Ok(await productProvider.UpdateProduct(product));
        [HttpPost, Route("RemoveProduct")]
        public async Task<IActionResult> Remove(ProductDomain product)
            => Ok(await productProvider.DeleteProduct(product.ProductID));
        [HttpPost, Route("GetProduct")]
        public async Task<IActionResult> GetProduct(ProductDomain product)
            => Ok(await productProvider.GetProductById(product.ProductID));
        [HttpGet, Route("GetProducts")]
        public async Task<IActionResult> GetProducts()
            => Ok(await productProvider.GetAllProducts());
        [HttpPost, Route("GetProductsByID")]
        public async Task<IActionResult> GetProductsByID(ProductDomain productDomain) => Ok(await productProvider.GetProductsByID(productDomain));
    }
}
