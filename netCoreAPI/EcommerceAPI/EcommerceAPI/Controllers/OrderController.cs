using Ecommerce.Core.Providers;
using Ecommerce.Shared.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderProvider orderProvider;

        public OrderController(IOrderProvider orderProvider)
        {
            this.orderProvider = orderProvider;
        }
        [HttpPost, Route("SubmitOrder")]
        public async Task<IActionResult> RegisterOrder(OrderDomain orderDomain) => Ok(await orderProvider.OrderRegisteration(orderDomain));
        [HttpGet, Route("GetOrders")]
        public async Task<IActionResult> GetOrders() => Ok(await orderProvider.GetOrderDetails());
        [HttpPost, Route("GetOrdersByCustomerID")]
        public async Task<IActionResult> GetOrder(int ID) => Ok(await orderProvider.GetOrderDetail(ID));
        [HttpPost, Route("GetDetailsByCustomerID")]
        public async Task<IActionResult> GetOrderbyID(int ID) => Ok(await orderProvider.GetOrder(ID));
        [HttpPost,Route("UpdateOrder")]
        public async Task<IActionResult> UpdateOrder(OrderDomain orderDomain) => Ok(await orderProvider.UpdateData(orderDomain));
    }
}
