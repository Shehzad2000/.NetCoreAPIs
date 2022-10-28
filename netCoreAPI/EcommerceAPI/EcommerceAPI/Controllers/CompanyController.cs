using Ecommerce.Core.Providers;
using Ecommerce.Shared.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {

        private readonly ICompanyProvider companyProvider;

        public CompanyController(ICompanyProvider companyProvider)
        {
            this.companyProvider = companyProvider;
        }
        [HttpPost, Route("RegisterCompany")]
        public async Task<IActionResult> Register(CompanyDomain companyDomain)
            => Ok(await companyProvider.RegisterCompany(companyDomain));
        [HttpPost, Route("UpdateCompanyDetails")]
        public async Task<IActionResult> Update(CompanyDomain companyDomain)
            => Ok(await companyProvider.UpdateCompanyDetails(companyDomain));
        [HttpPost, Route("RemoveCompany")]
        public async Task<IActionResult> Delete(CompanyDomain companyDomain)
            => Ok(await companyProvider.RemoveCompany(companyDomain.CompanyID));
        [HttpPost, Route("GetCompany")]
        public async Task<IActionResult> GetCompany(CompanyDomain companyDomain)
            => Ok(await companyProvider.GetCompany(companyDomain.CompanyID));
        [HttpGet, Route("GetAllCompaniesDetails")]
        public async Task<IActionResult> GetCompanyDetails()
            => Ok(await companyProvider.GetCompanies());
    }
}
