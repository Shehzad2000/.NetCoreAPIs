
using AutoMapper;
using Ecommerce.Shared.Domain;
using Ecommerce.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ecommerce.UI.Controllers
{
    public class AdminController : Controller
    {
        public IWebHostEnvironment WebHostEnvironment { get; }
        public IMapper Mapper;

        public AdminController(IWebHostEnvironment webHostEnvironment, IMapper mapper)
        {
            WebHostEnvironment = webHostEnvironment;
            Mapper = mapper;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(AdminDomain admin)
        {
            using (var Client = new HttpClient())
            {
                Client.BaseAddress = new Uri(MyApiConfiguration.BaseApiUrl);
                var result = await Client.PostAsJsonAsync("api/Admin/Login", admin);
                if (result.IsSuccessStatusCode)
                {

                    ViewBag.msg = "Login Successfull";
                    return View();
                }
                else
                {

                    ViewBag.msg = "Login is failed";
                    return View();
                }

            }
        }
        [HttpGet]
        public async Task<IActionResult> Registeration(int ID = 0)
        {
            AdminDomain admin = new AdminDomain();
            using (var Client = new HttpClient())
            {
                if (ID > 0)
                {
                    Client.BaseAddress = new Uri(MyApiConfiguration.BaseApiUrl);
                    admin.AdminID = ID;
                    var result = await Client.PostAsJsonAsync("api/Admin/GetAdminByID", admin);
                    if (result.IsSuccessStatusCode)
                    {
                        var data = result.Content.ReadAsStringAsync().Result;
                        admin = JsonConvert.DeserializeObject<AdminDomain>(data);
                    }

                }

            }
            AdminModel model = Mapper.Map<AdminModel>(admin);
            return View(new AdminModel());
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

        //[HttpPost]
        //public async Task<IActionResult> Registeration(AdminModel admin)
        //{
        //    AdminDomain adminDomain = new AdminDomain();

        //    adminDomain = Mapper.Map<AdminDomain>(admin);
        //    for (int i = 0; i < admin.MyImage.Count(); i++)
        //    {
        //        adminDomain.AdminImage = UploadedFile(admin.MyImage[i]);
        //    }

        //    using (var Client = new HttpClient())
        //    {
        //        if (admin.AdminID > 0)
        //        {
        //            Client.BaseAddress = new Uri(MyApiConfiguration.BaseApiUrl);
        //            var result = await Client.PostAsJsonAsync("api/Admin/Update", adminDomain);
        //            if (result.IsSuccessStatusCode)
        //            {
        //                ViewBag.msg = "Admin updated";
        //            }
        //            else
        //            {
        //                ViewBag.msg = "Oops,sorry admin updation is failed ";
        //            }
        //        }
        //        else
        //        {
        //            Client.BaseAddress = new Uri(MyApiConfiguration.BaseApiUrl);
        //            var result = await Client.PostAsJsonAsync("api/Admin/Register", admin);
        //            if (result.IsSuccessStatusCode)
        //            {
        //                ViewBag.msg = "Registeration is done successfully";
        //            }
        //            else
        //            {
        //                ViewBag.msg = "Oops Registeration is failed";

        //            }
        //        }

        //    }
        //    return View();
        //}
        [HttpGet]
        public async Task<IActionResult> GetAdmins()
        {
            using (var Client = new HttpClient())
            {
                Client.BaseAddress = new Uri(MyApiConfiguration.BaseApiUrl);
                var result = await Client.GetAsync("api/Admin/GetAdmins");
                if (result.IsSuccessStatusCode)
                {
                    var data = result.Content.ReadAsStringAsync().Result;
                    ViewBag.data = JsonConvert.DeserializeObject<List<AdminDomain>>(data);
                }
                else
                {
                    ViewBag.data = "Oops,something wrong";
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Remove(AdminDomain admin)
        {
            using (var Client = new HttpClient())
            {
                Client.BaseAddress = new Uri(MyApiConfiguration.BaseApiUrl);
                var result = await Client.PostAsJsonAsync("api/Admin/Delete", admin);
                if (result.IsSuccessStatusCode)
                {
                    //var data = result.Content.ReadAsStringAsync().Result;
                    //ViewBag.data = JsonConvert.DeserializeObject<List<AdminDomain>>(data);
                }
                else
                {
                    ViewBag.data = "Oops,something wrong";
                }
            }
            return View();
        }
    }
}
