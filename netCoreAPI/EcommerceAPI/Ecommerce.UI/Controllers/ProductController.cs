using AutoMapper;
using Ecommerce.Shared.Domain;
using Ecommerce.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ecommerce.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMapper mapper;

        [HttpGet]
        public ActionResult ProductView()
        {
            return View();
        }

        public ProductController(IWebHostEnvironment webHostEnvironment, IMapper Mapper)
        {
            WebHostEnvironment = webHostEnvironment;
            mapper = Mapper;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        [HttpGet]
        public async Task<IActionResult> RegisterProduct(int ID = 0)
        {
            ProductDomain domain = new ProductDomain();
            if (ID > 0)
            {
                using (var Client = new HttpClient())
                {
                    Client.BaseAddress = new Uri(MyApiConfiguration.BaseApiUrl);
                    domain.ProductID = ID;
                    var result = await Client.PostAsJsonAsync("api/Product/GetProduct", domain);
                    if (result.IsSuccessStatusCode)
                    {
                        var data = result.Content.ReadAsStringAsync().Result;
                        domain = JsonConvert.DeserializeObject<ProductDomain>(data);
                    }
                }
            }
            ProductModel model = mapper.Map<ProductModel>(domain);
            LoadCategory();
            LoadCompany();

            return View();
        }
        //        void Http(String ApiAddress, dynamic Domain,HttpClient Client)
        //        {
        //            Client.BaseAddress = new Uri(MyApiConfiguration.BaseApiUrl);
        //        var result = Client.GetAsync(ApiAddress).Result;
        //            if (result.IsSuccessStatusCode)
        //            {
        //                var data = result.Content.ReadAsStringAsync().Result;
        //        ViewBag.Data = JsonConvert.DeserializeObject<List<Domain>>(data);
        //            }
        //}
        void LoadCompany()
        {
            using (var Client = new HttpClient())
            {
                Client.BaseAddress = new Uri(MyApiConfiguration.BaseApiUrl);
                var result = Client.GetAsync("api/Company/GetAllCompaniesDetails").Result;
                if (result.IsSuccessStatusCode)
                {
                    var data = result.Content.ReadAsStringAsync().Result;
                    ViewBag.CompanyData = JsonConvert.DeserializeObject<List<CompanyDomain>>(data);
                }
            }
        }
        void LoadCategory()
        {

            using (var Client = new HttpClient())
            {
                Client.BaseAddress = new Uri(MyApiConfiguration.BaseApiUrl);
                var result = Client.GetAsync("api/Category/GetCategories").Result;
                if (result.IsSuccessStatusCode)
                {

                    var data = result.Content.ReadAsStringAsync().Result;
                    ViewBag.CatData = JsonConvert.DeserializeObject<List<CategoryDomain>>(data);
                }
            }
        }

        public async Task<JsonResult> LoadSubCategory(int CatID)
        {
            using (var Client = new HttpClient())
            {
                SubCategoryDomain domain = new SubCategoryDomain()
                {
                    CategoryID = CatID
                };
                Client.BaseAddress = new Uri(MyApiConfiguration.BaseApiUrl);
                var result = Client.PostAsJsonAsync("api/SubCategory/GetSubCategoryByCatID", domain).Result;
                if (result.IsSuccessStatusCode)
                {
                    var data = result.Content.ReadAsStringAsync().Result;
                    return Json(JsonConvert.DeserializeObject<List<SubCategoryDomain>>(data), System.Web.Mvc.JsonRequestBehavior.AllowGet);
                }
            }
            return Json(null);
        }
        private string UploadFile(IFormFile img)
        {
            string uniqueFileName = null;
            if (img != null)
            {
                string uploadFolder = Path.Combine(WebHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + img.FileName;
                string filePath = Path.Combine(uploadFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    img.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }


        [HttpPost]
        public async Task<IActionResult> RegisterProduct(ProductModel model)
        {
            ProductDomain productDomain = mapper.Map<ProductDomain>(model);
            //productDomain.MainImage = UploadFile(model.MainImage);
            //for (int i = 0; i < model.OtherImages.Count(); i++)
            //{
            //    productDomain.OtherImages = UploadFile(model.OtherImages[i]);
            //}
            using (var Client = new HttpClient())
            {
                Client.BaseAddress = new Uri(MyApiConfiguration.BaseApiUrl);
                var result = (productDomain.ProductID == 0) ? (await Client.PostAsJsonAsync("api/Product/AddProduct", productDomain)) :
                    (await Client.PostAsJsonAsync("api/Product/UpdateProduct", productDomain));
                if (result.IsSuccessStatusCode)
                {
                    ViewBag.msg = "Data has been submitted successfully";
                }
                else
                {
                    ViewBag.msg = "Oops there is something wrong";
                }
            }
            LoadCategory();
            LoadCompany();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UnRegisterProduct(ProductModel model)
        {
            ProductDomain productDomain = mapper.Map<ProductDomain>(model);
            using (var Client = new HttpClient())
            {
                Client.BaseAddress = new Uri(MyApiConfiguration.BaseApiUrl);
                var result = await Client.PostAsJsonAsync("api/Product/RemoveProduct", productDomain);
                if (result.IsSuccessStatusCode)
                {
                    ViewBag.msg = "Data has been removed successfully";
                }
                else { ViewBag.msg = "Oops,there is somthing wrong"; }
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            using (var Client = new HttpClient())
            {
                Client.BaseAddress = new Uri(MyApiConfiguration.BaseApiUrl);
                var result = await Client.GetAsync("api/Product/GetProducts");
                if (result.IsSuccessStatusCode)
                {
                    var data = result.Content.ReadAsStringAsync().Result;
                    ViewBag.data = JsonConvert.DeserializeObject<List<ProductDomain>>(data);
                }
                else
                {
                    ViewBag.data = "Oops there is something wrong";
                }
            }
            return View();
        }
    }
}
