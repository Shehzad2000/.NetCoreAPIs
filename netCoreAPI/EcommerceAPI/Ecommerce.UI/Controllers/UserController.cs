using AutoMapper;
using Ecommerce.Shared.Domain;
using Ecommerce.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ecommerce.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly IMapper mapper;

        public UserController(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UserRegisteration(UserModel userModel)
        {
            UserDomain user = mapper.Map<UserDomain>(userModel);
            using (var Client = new HttpClient())
            {
                Client.BaseAddress = new Uri(MyApiConfiguration.BaseApiUrl);
                var result = (user.UserID == 0) ? (await Client.PostAsJsonAsync("api/User/", user)) :
                    (await Client.PostAsJsonAsync("api/User/", user));
                if (result.IsSuccessStatusCode)
                    ViewBag.msg = "Data has been Submitted Successfully";
                else
                    ViewBag.msg = "Oops,something is wrong";
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UserRegisteration(int ID = 0)
        {
            UserDomain userDomain = new UserDomain();
            if (ID > 0)
            {
                using (var Client = new HttpClient())
                {
                    userDomain.UserID = ID;
                    Client.BaseAddress = new Uri(MyApiConfiguration.BaseApiUrl);
                    var res = await Client.PostAsJsonAsync("api/User/", userDomain);
                    if (res.IsSuccessStatusCode)
                    {
                        var data = res.Content.ReadAsStringAsync().Result;
                        userDomain = JsonConvert.DeserializeObject<UserDomain>(data);
                    }
                }
            }
            UserModel userModel = mapper.Map<UserModel>(userDomain);
            return View(userModel);
        }
        [HttpPost]
        public async Task<IActionResult> UserLogin(UserModel userModel)
        {
            UserDomain userDomain = mapper.Map<UserDomain>(userModel);
            using (var Client = new HttpClient())
            {
                Client.BaseAddress = new Uri(MyApiConfiguration.BaseApiUrl);
                var res = await Client.PostAsJsonAsync("api/User/", userDomain);
                if (res.IsSuccessStatusCode)
                    ViewBag.msg = "Login Successfull";
                else
                    ViewBag.msg = "Login Failed";
            }
            return View();

        }
        [HttpGet]
        public IActionResult UserLogin()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            using (var Client = new HttpClient())
            {
                Client.BaseAddress = new Uri(MyApiConfiguration.BaseApiUrl);
                var result = await Client.GetAsync("api/User/");
                if (result.IsSuccessStatusCode)
                {
                    var data = result.Content.ReadAsStringAsync().Result;
                    ViewBag.data = JsonConvert.DeserializeObject<List<UserDomain>>(data);
                }
                else
                {
                    ViewBag.data = "Oops,something wrong";
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Remove(UserDomain user)
        {
            using (var Client = new HttpClient())
            {
                Client.BaseAddress = new Uri(MyApiConfiguration.BaseApiUrl);
                var result = await Client.PostAsJsonAsync("api/User/", user);
                if (result.IsSuccessStatusCode)
                {
                    ViewBag.data = "Data has been deleted successfully";
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
