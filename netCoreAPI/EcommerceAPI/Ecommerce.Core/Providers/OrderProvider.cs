using Ecommerce.Core.Data;
using Ecommerce.Shared.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Core.Providers
{
    public interface IOrderProvider
    {
        Task<string> OrderRegisteration(OrderDomain orderDomain);
        Task<List<MyDomains>> GetOrderDetails();
        Task<List<MyDomains>> GetOrderDetail(int ID);
        Task<MyDomains> GetOrder(int ID);
        Task<string> UpdateData(OrderDomain orderDomain);
    }
    public class OrderProvider : IOrderProvider
    {
        private readonly MyDbContext db;

        public OrderProvider(MyDbContext db)
        {
            this.db = db;
        }

        public async Task<List<MyDomains>> GetOrderDetails()
        {
            return await Task.FromResult((from o in db.orderDetails
                                          join order in db.orders on o.OrderID equals order.OrderID
                                          join c in db.customers on o.CustomerID equals c.CustomerID
                                          join p in db.products on o.ProductID equals p.ProductID
                                          select new MyDomains
                                          {
                                              product = p,
                                              customer = c,
                                              orderDetail = o,
                                              order=order,
                                              
                                          }
                                          ).ToList());
        }

        public async Task<List<MyDomains>> GetOrderDetail(int ID)
        {
            List<MyDomains> list = await Task.FromResult((from o in db.orderDetails
                                                          join or in db.orders on o.OrderID equals or.OrderID
                                                          join c in db.customers on o.CustomerID equals c.CustomerID
                                                          join p in db.products on o.ProductID equals p.ProductID
                                                          select new MyDomains
                                                          {
                                                              product = p,
                                                              customer = c,
                                                              orderDetail = o,
                                                              order = or,
                                                          }
                                          ).Where(x => x.customer.CustomerID == ID).ToList());
            return list;
        }
        public async Task<MyDomains> GetOrder(int ID)
        {
            return  await Task.FromResult((from o in db.orderDetails
                                                          join or in db.orders on o.OrderID equals or.OrderID
                                                          join c in db.customers on o.CustomerID equals c.CustomerID
                                                          join p in db.products on o.ProductID equals p.ProductID
                                                          select new MyDomains
                                                          {
                                                              product = p,
                                                              customer = c,
                                                              orderDetail = o,
                                                              order = or,
                                                          }
                                          ).Where(x => x.customer.CustomerID == ID).FirstOrDefault());
            
        }
        public async Task<string> OrderRegisteration(OrderDomain orderDomain)
        {
            await db.orders.AddAsync(orderDomain);
            await db.SaveChangesAsync();
            List<CartDomain> cart = await Task.FromResult(db.carts.Where(x => x.CustomerID == 1).ToList());
            int MaxOrderID = db.orders.Max(x => x.OrderID);
            foreach (var item in cart)
            {
                OrderDetailDomain orderDetail = new OrderDetailDomain();
                orderDetail.OrderID = MaxOrderID;
                orderDetail.ProductID = item.ProductID;
                orderDetail.CustomerID = 1;
                orderDetail.UnitPrice = item.PricePerUnit;
                orderDetail.Quantity = item.Quantity;
                await db.orderDetails.AddAsync(orderDetail);
                await db.SaveChangesAsync();

                db.carts.Remove(item);
                await db.SaveChangesAsync();
            }
            return "Order has been successfully submitted";
        }
        public async Task<string> UpdateData(OrderDomain orderDomain)
        {
            await Task.FromResult(db.orders.Update(orderDomain));
            await db.SaveChangesAsync();
            return "Data has been updated successfully";
        }
    }
}
