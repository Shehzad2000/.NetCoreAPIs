using Ecommerce.Core.Providers;
using Ecommerce.Shared.Domain;
using Ecommerce.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerProvider customerProvider;

        public CustomerController(ICustomerProvider customerProvider)
        {
            this.customerProvider = customerProvider;
        }
        [HttpPost, Route("RegisterCustomer")]
        public async Task<IActionResult> RegisterCustomer([FromForm] CustomerModel custumer)
        {
            CustumerDomain custumerDomain = new CustumerDomain();
            return Ok(await customerProvider.CustomerRegisteration(custumerDomain));
        }

        [HttpPost, Route("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer(CustumerDomain custumerDomain)
        => Ok(await customerProvider.UpdateCustomerDetails(custumerDomain));
        [HttpPost, Route("UnregisterCustomer")]
        public async Task<IActionResult> UnRegisterCustomer(CustumerDomain custumerDomain)
            => Ok(await customerProvider.RemoveCustomer(custumerDomain.CustomerID));
        [HttpPost, Route("Login")]
        public async Task<IActionResult> LoginCustomer(CustumerDomain custumerDomain)
            => Ok(await customerProvider.LoginCustomer(custumerDomain));
        [HttpGet, Route("GetCustomers")]
        public async Task<IActionResult> GetAllCustomers()
            => Ok(await customerProvider.GetAllCustomers());
        [HttpPost, Route("GetCustomerByID")]
        public async Task<IActionResult> GetCustomer(CustumerDomain custumerDomain)
            => Ok(await customerProvider.GetCustomerDetails(custumerDomain.CustomerID));
    }
}
