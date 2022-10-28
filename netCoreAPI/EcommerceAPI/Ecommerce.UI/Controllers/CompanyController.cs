using AutoMapper;
using Ecommerce.Core.Providers;
using Ecommerce.Shared.Domain;
using Ecommerce.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ecommerce.UI.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyProvider companyProvider;

        public CompanyController(ICompanyProvider companyProvider, IMapper mapper)
        {
            this.companyProvider = companyProvider;
            Mapper = mapper;
        }

        public IMapper Mapper { get; }

        [HttpGet]
        public async Task<IActionResult> RegisterCompany(int ID = 0)
        {
            CompanyDomain companyDomain = new CompanyDomain();
            if (ID > 0)
            {
                using (var Client = new HttpClient())
                {
                    companyDomain.CompanyID = ID;
                    Client.BaseAddress = new Uri(MyApiConfiguration.BaseApiUrl);
                    var res = await Client.PostAsJsonAsync("api/Company/GetCompany", companyDomain);
                    if (res.IsSuccessStatusCode)
                    {
                        var data = res.Content.ReadAsStringAsync().Result;
                        ViewBag.Data = JsonConvert.DeserializeObject<CompanyDomain>(data);
                    }
                }
            }
            CompanyModel companyModel = Mapper.Map<CompanyModel>(companyDomain);
            return View(companyModel);
        }
        [HttpPost]
        public async Task<IActionResult> RegisterCompany(CompanyModel model)
        {
            CompanyDomain companyDomain = Mapper.Map<CompanyDomain>(model);
            using (var Client = new HttpClient())
            {

                Client.BaseAddress = new Uri(MyApiConfiguration.BaseApiUrl);
                var res = (companyDomain.CompanyID == 0) ? (await Client.PostAsJsonAsync("api/Company/RegisterCompany", companyDomain)) :
                    (await Client.PostAsJsonAsync("api/Company/UpdateCompanyDetails", companyDomain));
                if (res.IsSuccessStatusCode)
                    ViewBag.msg = "Data has been submitted successfully";
                else
                    ViewBag.msg = "OOps,something is wrong";
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RemoveCategory(CompanyModel companyModel)
        {
            CompanyDomain companyDomain = Mapper.Map<CompanyDomain>(companyModel);
            using (var Client = new HttpClient())
            {
                Client.BaseAddress = new Uri(MyApiConfiguration.BaseApiUrl);
                var res = await Client.PostAsJsonAsync("api/Company/RemoveCompany", companyDomain);
                if (res.IsSuccessStatusCode)
                    ViewBag.msg = "Data has been removed successfully";
                else
                    ViewBag.msg = "OOps,something is wrong";
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetCompaniesDetail(CompanyModel companyModel)
        {
            using (var Client = new HttpClient())
            {
                Client.BaseAddress = new Uri(MyApiConfiguration.BaseApiUrl);
                var res = await Client.GetAsync("api/Company/GetAllCompaniesDetails");
                if (res.IsSuccessStatusCode)
                    ViewBag.Data = JsonConvert.DeserializeObject<List<CompanyDomain>>(res.Content.ReadAsStringAsync().Result);
                else
                    ViewBag.Data = "Oops,something is wrong";
            }
            return View();
        }
    }
}
