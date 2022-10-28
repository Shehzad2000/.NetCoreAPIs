using Ecommerce.Core.Data;
using Ecommerce.Shared.Domain;

namespace Ecommerce.Core.Providers
{
    public interface IAdminProvider
    {
        Task<string> AdminRegisteration(AdminDomain domains);
        Task<AdminDomain> AdminLogin(AdminDomain admin);
        Task<string> UpdateAdmin(AdminDomain admin);
        Task<string> RemoveAdmin(int ID);
        Task<List<AdminDomain>> GetAllAdmins();
        Task<AdminDomain> GetAdminByID(int ID);
    }
    public class AdminProvider : IAdminProvider
    {

        public AdminProvider(MyDbContext db)
        {
            Db = db;
        }

        public MyDbContext Db { get; }

        public async Task<AdminDomain> AdminLogin(AdminDomain admin)
        {
            return await Task.FromResult(Db.admins.Where(x => x.AdminID == admin.AdminID && x.AdminPassword == admin.AdminPassword).FirstOrDefault());
        }

        public async Task<string> AdminRegisteration(AdminDomain model)
        {
            AdminDomain adminDomain = await Task.FromResult(Db.admins.Where(x => x.AdminID == model.AdminID && x.AdminPassword == model.AdminPassword).FirstOrDefault());
            if (adminDomain != null)
            {
                return "Admin is already exist";
            }
            Db.admins.Add(model);
            Db.SaveChanges();
            return "Admin is registered successfully";
        }

        public async Task<AdminDomain> GetAdminByID(int ID)
        {
            return await Task.FromResult(Db.admins.Find(ID));
        }

        public async Task<List<AdminDomain>> GetAllAdmins()
        {
            return await Task.FromResult(Db.admins.ToList());
        }

        public async Task<string> RemoveAdmin(int ID)
        {
            await Task.FromResult(Db.admins.Remove(Db.admins.Find(ID)));
            Db.SaveChanges();
            return "Data has been removed successfully";

        }

        public async Task<string> UpdateAdmin(AdminDomain admin)
        {
            AdminDomain admin1 = await Task.FromResult(Db.admins.Where(x => x.AdminEmail == admin.AdminEmail && x.AdminPassword == admin.AdminPassword).FirstOrDefault());
            if (admin1 != null && admin1.AdminID == admin.AdminID)
            {
                return "User is already exist";
            }
            Db.admins.Update(admin);
            Db.SaveChanges();
            return "Daata has been updated successfully";
        }
    }
}
