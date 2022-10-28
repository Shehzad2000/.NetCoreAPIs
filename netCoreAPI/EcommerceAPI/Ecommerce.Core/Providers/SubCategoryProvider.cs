using Ecommerce.Core.Data;
using Ecommerce.Shared.Domain;

namespace Ecommerce.Core.Providers
{
    public interface ISubCategoryProvider
    {
        Task<string> RegisterSubCategory(SubCategoryDomain subCategory);
        Task<string> UpdateSubCategory(SubCategoryDomain subCategory);
        Task<string> DeleteSubCategory(int ID);
        Task<SubCategoryDomain> GetSubCategory(SubCategoryDomain category);
        Task<List<SubCategoryDomain>> GetSubCategoryByCatID(SubCategoryDomain subcategory);
        Task<List<CategoryDomain>> GetCategories();
        Task<List<SubCategoryDomain>> GetAllSubCategories();

    }
    public class SubCategoryProvider : ISubCategoryProvider
    {
        private readonly MyDbContext db;

        public SubCategoryProvider(MyDbContext db)
        {
            this.db = db;
        }

        public async Task<string> DeleteSubCategory(int ID)
        {

            await Task.FromResult(db.subCategories.Remove(db.subCategories.Find(ID)));
            await db.SaveChangesAsync();
            return "Data has been removed successfully";
        }

        public async Task<List<SubCategoryDomain>> GetAllSubCategories()
        {
            return await Task.FromResult(db.subCategories.ToList());
        }

        public async Task<List<CategoryDomain>> GetCategories()
        {
            return await Task.FromResult(db.categories.ToList());

        }

        public async Task<SubCategoryDomain> GetSubCategory(SubCategoryDomain subcategory)
        {
            return await db.subCategories.FindAsync(subcategory.SubCategoryId);
        }
        public async Task<List<SubCategoryDomain>> GetSubCategoryByCatID(SubCategoryDomain subcategory)
        {
            return await Task.FromResult(db.subCategories.Where(x => x.CategoryID == subcategory.CategoryID).ToList());
        }

        public async Task<string> RegisterSubCategory(SubCategoryDomain subCategory)
        {
            SubCategoryDomain sub = await Task.FromResult(db.subCategories.Where(x => x.SubCategoryName == subCategory.SubCategoryName).FirstOrDefault());
            if (sub != null)
            {
                return "SubCategory is already exist";
            }
            await db.subCategories.AddAsync(subCategory);
            await db.SaveChangesAsync();
            return "SubCategory is registered successfully";
        }

        public async Task<string> UpdateSubCategory(SubCategoryDomain subCategory)
        {
            //SubCategoryDomain sub = await Task.FromResult(db.subCategories.Where(x => x.SubCategoryName == subCategory.SubCategoryName).FirstOrDefault());
            //if (sub != null && sub.SubCategoryId == subCategory.SubCategoryId)
            //{
            //    return "SubCategory is already existed";
            //}
            await Task.FromResult(db.subCategories.Update(subCategory));
            await db.SaveChangesAsync();
            return "SubCategory has been updated successfully";
        }


    }
}
