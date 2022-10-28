using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.UI.Controllers
{
    public class CategoryController : Controller
    {
        //private readonly IWebHostEnvironment webHostEnvironment;
        //private readonly IMapper Mapper;

        //public CategoryController(IWebHostEnvironment webHostEnvironment,IMapper mapper)
        //{
        //    this.webHostEnvironment = webHostEnvironment;
        //    this.Mapper = mapper;
        //}

        public IActionResult Index()
        {
            return View();
        }
        //[HttpGet]
        //public async Task<IActionResult> RegisterCategory(int ID = 0)
        //{
        //    CategoryDomain category=new CategoryDomain();
        //    if (ID > 0)
        //    {
        //        using(var Client=new HttpClient())
        //        {
        //            Client.BaseAddress=new Uri(MyApiConfiguration.BaseApiUrl);
        //            category.CategoryID = ID;
        //            var Result=await Client.PostAsJsonAsync("api/Category/GetCategory",category);
        //            if (Result.IsSuccessStatusCode)
        //            {
        //                var data=Result.Content.ReadAsStringAsync().Result;
        //                category=JsonConvert.DeserializeObject<CategoryDomain>(data);
        //            }
        //        }

        //    }
        //    using (var Client = new HttpClient())
        //    {
        //        Client.BaseAddress = (new Uri(MyApiConfiguration.BaseApiUrl));
        //        var result = Client.GetAsync("api/Category/GetCategories").Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            var data = result.Content.ReadAsStringAsync().Result;
        //            ViewBag.data = JsonConvert.DeserializeObject<List<CategoryDomain>>(data);
        //        }
        //        //else
        //        //{
        //        //    ViewBag.data = "Oops,something is wrong";
        //        //}
        //    }
        //    CategoryModel categoryModel = Mapper.Map<CategoryModel>(category);
        //    return View();
        //}
        //[HttpPost]
        //public async Task<IActionResult> RegisterCategory(CategoryModel model)
        //{
        //    CategoryDomain category=Mapper.Map<CategoryDomain>(model);
        //    using (var Client = new HttpClient())
        //    {
        //        Client.BaseAddress = new Uri(MyApiConfiguration.BaseApiUrl);
        //        var result = (category.CategoryID==0)? await Client.PostAsJsonAsync("api/Category/AddCategory", category):
        //            await Client.PostAsJsonAsync("api/Category/UpdateCategory", category);
        //        if (result.IsSuccessStatusCode)
        //        {
        //            ViewBag.msg="Data has been Submitted Successfully";
        //        }
        //        else
        //        {
        //            ViewBag.msg = "Oops,there is something wrong";
        //        }
        //    }
        //    return View();
        //}
        //[HttpPost]
        //public async Task<IActionResult> UnregisterCategory(CategoryModel category)
        //{
        //    using(var Client = new HttpClient())
        //    {
        //        Client.BaseAddress=new Uri(MyApiConfiguration.BaseApiUrl);
        //        var result = await Client.PostAsJsonAsync("api/Category/DeleteCategory", category);
        //        if (result.IsSuccessStatusCode)
        //        {
        //            ViewBag.msg= "Data has been removed successfully";
        //        }
        //        else
        //        {
        //            ViewBag.msg= "OOps there is something wrong";
        //        }

        //    }
        //    return View();
        //}

        //void LoadCat()
        //{
        //    using (var Client = new HttpClient())
        //    {
        //        Client.BaseAddress = (new Uri(MyApiConfiguration.BaseApiUrl));
        //        var result = Client.GetAsync("api/Category/GetCategories").Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            var data = result.Content.ReadAsStringAsync().Result;
        //            ViewBag.data = JsonConvert.DeserializeObject<List<CategoryDomain>>(data);
        //        }
        //        //else
        //        //{
        //        //    ViewBag.data = "Oops,something is wrong";
        //        //}
        //    }
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetCategories()
        //{
        //    using (var Client = new HttpClient())
        //    {
        //        Client.BaseAddress=(new Uri(MyApiConfiguration.BaseApiUrl));
        //        var result=await Client.GetAsync("api/Category/GetCategories");
        //        if (result.IsSuccessStatusCode)
        //        {
        //            var data = result.Content.ReadAsStringAsync().Result;
        //            ViewBag.data=JsonConvert.DeserializeObject<List<CategoryDomain>>(data);
        //        }
        //        else
        //        {
        //            ViewBag.data = "Oops,something is wrong";
        //        }
        //    }
        //    return View();
        //}

    }
}
