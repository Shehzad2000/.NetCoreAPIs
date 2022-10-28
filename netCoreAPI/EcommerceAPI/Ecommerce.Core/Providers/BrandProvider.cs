using Ecommerce.Core.Data;
using Ecommerce.Shared.Domain;

namespace Ecommerce.Core.Providers
{
    public interface IBrandProvider
    {
        Task<string> BrandRegisteration(BrandDomain brandDomain);
        Task<string> UpdateBrandDetails(BrandDomain brandDomain);
        Task<BrandDomain> GetBrand(int id);
        Task<List<BrandDomain>> GetBrands();
        Task<string> RemoveBrand(int id);
    }
    public class BrandProvider : IBrandProvider
    {
        private readonly MyDbContext db;

        public BrandProvider(MyDbContext db)
        {
            this.db = db;
        }
        public async Task<string> BrandRegisteration(BrandDomain brandDomain)
        {
            BrandDomain brand = await Task.FromResult(db.brands.Where(x => x.BrandName == brandDomain.BrandName).FirstOrDefault());
            if (brand != null)
            {
                return "Brand is already exist";
            }
            await db.brands.AddAsync(brandDomain);
            await db.SaveChangesAsync();
            return "Data has been submitted successfully";

        }

        public async Task<BrandDomain> GetBrand(int id)
        {
            return await db.brands.FindAsync(id);
        }

        public async Task<List<BrandDomain>> GetBrands()
        {
            return await Task.FromResult(db.brands.ToList());
        }

        public async Task<string> RemoveBrand(int id)
        {
            await Task.FromResult(db.brands.Remove(db.brands.Find(id)));
            await db.SaveChangesAsync();
            return "Data has been removed successfully";
        }

        public async Task<string> UpdateBrandDetails(BrandDomain brandDomain)
        {
            await Task.FromResult(db.brands.Update(brandDomain));
            await db.SaveChangesAsync(true);
            return "Data has been Updated successfully";
        }
    }
}
