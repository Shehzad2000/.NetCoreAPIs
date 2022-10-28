using Ecommerce.Core.Data;
using Ecommerce.Shared.Domain;

namespace Ecommerce.Core.Providers
{
    public interface ICustomerProvider
    {
        Task<string> CustomerRegisteration(CustumerDomain custumerDomain);
        Task<string> UpdateCustomerDetails(CustumerDomain custumerDomain);
        Task<string> RemoveCustomer(int ID);
        Task<string> LoginCustomer(CustumerDomain custumerDomain);
        Task<CustumerDomain> GetCustomerDetails(int ID);
        Task<List<CustumerDomain>> GetAllCustomers();
    }
    public class CustomerProvider : ICustomerProvider
    {
        private readonly MyDbContext db;

        public CustomerProvider(MyDbContext db)
        {
            this.db = db;
        }
        public async Task<string> CustomerRegisteration(CustumerDomain custumerDomain)
        {
            CustumerDomain custumer = await Task.FromResult(db.customers.Where(x => x.CustomerEmail == custumerDomain.CustomerEmail && x.CustomerPassword == custumerDomain.CustomerPassword).FirstOrDefault());
            if (custumer != null)
            {
                return "Customer is already exists";
            }
            await db.customers.AddAsync(custumerDomain);
            await db.SaveChangesAsync();
            return "Customer is added successfully";
        }

        public async Task<List<CustumerDomain>> GetAllCustomers()
        {
            return await Task.FromResult(db.customers.ToList());
        }

        public async Task<CustumerDomain> GetCustomerDetails(int ID)
        {
            return await db.customers.FindAsync(ID);
        }

        public async Task<string> LoginCustomer(CustumerDomain custumerDomain)
        {
            CustumerDomain custumer = await Task.FromResult(db.customers.Where(x => x.CustomerEmail == custumerDomain.CustomerEmail).FirstOrDefault());
            return (custumer == null) ? "Wrong Email or Password" : "Login Successfully";
        }

        public async Task<string> RemoveCustomer(int ID)
        {
            await Task.FromResult(db.customers.Remove(db.customers.Find(ID)));
            await db.SaveChangesAsync();
            return "Data has been removed successfully";
        }

        public async Task<string> UpdateCustomerDetails(CustumerDomain custumerDomain)
        {
            CustumerDomain c = await Task.FromResult(db.customers.Where(x => x.CustomerEmail == custumerDomain.CustomerEmail && x.CustomerPassword == custumerDomain.CustomerPassword).FirstOrDefault());
            if (c != null && c.CustomerID == custumerDomain.CustomerID)
            {
                return "User is already exist";
            }
            await Task.FromResult(db.customers.Update(custumerDomain));
            await db.SaveChangesAsync();
            return "Customer has been updated successfully";
        }
    }
}
