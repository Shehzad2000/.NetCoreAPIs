using Ecommerce.Shared.Domain;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace E_Commerce.UI.Controllers
{
    public class ShowProductsController : Controller
    {
       
        [HttpGet]
        public IActionResult Index()
        {
            
            return View();
        }
        //private void GetData()
        
        
        //{
        //    using (var Client = new HttpClient())
        //    {
        //        Client.BaseAddress = new Uri("https://localhost:7299/");
        //        var Result = Client.GetAsync("api/Product/GetProducts").Result;
        //        if (Result.IsSuccessStatusCode)
        //        {
        //            var data = Result.Content.ReadAsStringAsync().Result;
        //            ViewBag.Data = JsonConvert.DeserializeObject<List<MyDomains>>(data);
        //        }
        //    }

        //}
    }
}
