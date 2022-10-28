using AutoMapper;
using Ecommerce.Shared.Domain;
using Ecommerce.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ecommerce.UI.Controllers
{
    public class SubCategoryController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IMapper Mapper;

        public SubCategoryController(IWebHostEnvironment webHostEnvironment, IMapper mapper)
        {
            this.webHostEnvironment = webHostEnvironment;
            Mapper = mapper;
        }

        void LoadCat()
        {
            using (var Client = new HttpClient())
            {
                Client.BaseAddress = new Uri(MyApiConfiguration.BaseApiUrl);
                var result = Client.GetAsync("api/Category/GetCategories").Result;
                if (result.IsSuccessStatusCode)
                {
                    var data = result.Content.ReadAsStringAsync().Result;
                    ViewBag.CatList = JsonConvert.DeserializeObject<List<CategoryDomain>>(data);
                }
                else
                {
                    ViewBag.data = "Oops,something wrong";
                }
            }

        }

        [HttpGet]
        public async Task<IActionResult> RegisterSubCategory(int ID = 0)
        {
            SubCategoryDomain subCategoryDomain = new SubCategoryDomain();
            using (HttpClient client = new HttpClient())
            {
                if (ID > 0)
                {
                    client.BaseAddress = new Uri(MyApiConfiguration.BaseApiUrl);
                    subCategoryDomain.SubCategoryId = ID;
                    var result = await client.PostAsJsonAsync("api/SubCategory/AddSubcategory", subCategoryDomain);
                    if (result.IsSuccessStatusCode)
                    {
                        var data = result.Content.ReadAsStringAsync().Result;
                        subCategoryDomain = JsonConvert.DeserializeObject<SubCategoryDomain>(data);
                    }
                }
            };
            SubCategoryModel subCategory = Mapper.Map<SubCategoryModel>(subCategoryDomain);
            LoadCat();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterSubCategory(SubCategoryModel subCategory)
        {
            SubCategoryDomain subCategory1 = Mapper.Map<SubCategoryDomain>(subCategory);
            using (HttpClient Client = new HttpClient())
            {
                if (subCategory.SubCategoryId > 0)
                {
                    Client.BaseAddress = new Uri(MyApiConfiguration.BaseApiUrl);
                    var result = await Client.PostAsJsonAsync("api/SubCategory/UpdateSubCategory", subCategory1);
                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.msg = "SubCategory is updated successfully";
                    }
                    else
                    {
                        ViewBag.msg = "Oops,Something went wrong";
                    }
                }
                else
                {
                    Client.BaseAddress = new Uri(MyApiConfiguration.BaseApiUrl);
                    var result = await Client.PostAsJsonAsync("api/SubCategory/AddSubCategory", subCategory1);
                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.msg = "SubCategory is updated successfully";
                    }
                    else
                    {
                        ViewBag.msg = "Oops,Something went wrong";
                    }
                }
            }
            LoadCat();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RemoveSubCategory(SubCategoryModel subCategory)
        {
            using (var Client = new HttpClient())
            {
                Client.BaseAddress = new Uri(MyApiConfiguration.BaseApiUrl);
                var Result = await Client.PostAsJsonAsync("api/SubCategory/DeleteSubCategory", subCategory);
                if (Result.IsSuccessStatusCode)
                {
                    ViewBag.msg = "Data has been Deleted Successfully";
                }
                else
                {
                    ViewBag.msg = "Oops,Something went wrong";
                }
            }
            return View();
        }
    }
}
