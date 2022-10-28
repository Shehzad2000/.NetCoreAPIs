using Ecommerce.Core.Data;
using Ecommerce.Shared.Domain;

namespace Ecommerce.Core.Providers
{
    public interface ICompanyProvider
    {
        Task<string> RegisterCompany(CompanyDomain company);
        Task<string> UpdateCompanyDetails(CompanyDomain company);
        Task<string> RemoveCompany(int ID);
        Task<List<CompanyDomain>> GetCompanies();
        Task<CompanyDomain> GetCompany(int ID);

    }
    public class CompanyProvider : ICompanyProvider
    {
        private readonly MyDbContext db;

        public CompanyProvider(MyDbContext db)
        {
            this.db = db;
        }

        public async Task<List<CompanyDomain>> GetCompanies()
        {
            return await Task.FromResult(db.companies.ToList());
        }

        public async Task<CompanyDomain> GetCompany(int ID)
        {
            return await db.companies.FindAsync(ID);
        }

        public async Task<string> RegisterCompany(CompanyDomain company)
        {
            CompanyDomain company1 = await Task.FromResult(db.companies.Where(x => x.CompanyName == company.CompanyName).FirstOrDefault());
            if (company1 != null)
            {
                return "Company is already registered";
            }
            await db.companies.AddAsync(company);
            await db.SaveChangesAsync();
            return "Company is registered successfully";
        }

        public async Task<string> RemoveCompany(int ID)
        {
            await Task.FromResult(db.companies.Remove(db.companies.Find(ID)));
            await db.SaveChangesAsync();
            return "Data has Been successfully removed";
        }

        public async Task<string> UpdateCompanyDetails(CompanyDomain company)
        {
            CompanyDomain company1 = await Task.FromResult(db.companies.Where(x => x.CompanyName == company.CompanyName).FirstOrDefault());
            if (company1 != null && company1.CompanyID == company.CompanyID)
            {
                return "company Name is already exists";
            }
            await Task.FromResult(db.companies.Update(company));
            await db.SaveChangesAsync();
            return "company has been updated successfully"; ;
        }
    }
}
