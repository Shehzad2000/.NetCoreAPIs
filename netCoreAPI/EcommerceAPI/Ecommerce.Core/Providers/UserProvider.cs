using Ecommerce.Core.Data;
using Ecommerce.Shared.Domain;

namespace Ecommerce.Core.Providers
{
    public interface IUserProvider
    {
        Task<string> UserRegisteration(UserDomain User);
        Task<UserDomain> UserLogin(UserDomain User);
        Task<string> UpdateUser(UserDomain User);
        Task<string> DeleteUser(int ID);
        Task<UserDomain> GetUser(UserDomain category);
        Task<List<UserDomain>> GetAllUsers();
    }
    public class UserProvider : IUserProvider
    {
        private readonly MyDbContext db;

        public UserProvider(MyDbContext db)
        {
            this.db = db;
        }

        public async Task<string> DeleteUser(int ID)
        {

            await Task.FromResult(db.users.Remove(db.users.Find(ID)));
            await db.SaveChangesAsync();
            return "Data has been removed successfully";
        }

        public async Task<List<UserDomain>> GetAllUsers()
        {
            return await Task.FromResult(db.users.ToList());
        }


        public async Task<UserDomain> GetUser(UserDomain User)
        {
            return await db.users.FindAsync(User.UserID);
        }

        public async Task<string> UserRegisteration(UserDomain User)
        {
            UserDomain sub = await Task.FromResult(db.users.Where(x => x.UserEmail == User.UserEmail && x.UserPassword == User.UserPassword).FirstOrDefault());
            if (sub != null)
            {
                return "User is already exist";
            }
            await db.users.AddAsync(User);
            await db.SaveChangesAsync();
            return "User is registered successfully";
        }

        public async Task<string> UpdateUser(UserDomain User)
        {
            UserDomain sub = await Task.FromResult(db.users.Where(x => x.UserName == User.UserName).FirstOrDefault());
            if (sub != null && sub.UserID == User.UserID)
            {
                return "User is already existed";
            }
            await Task.FromResult(db.users.Update(User));
            await db.SaveChangesAsync();
            return "User has been updated successfully";
        }

        public async Task<UserDomain> UserLogin(UserDomain User)
        {
            return await Task.FromResult(db.users.Where(x => x.UserEmail == User.UserEmail && x.UserPassword == User.UserPassword).FirstOrDefault());
        }
    }
}
