using Ecommerce.Core.Data;
using Ecommerce.Shared.Domain;

namespace Ecommerce.Core.Providers
{
    public interface ICategoryProvider
    {
        Task<string> RegisterCategory(CategoryDomain category);
        Task<string> UpdateCategory(CategoryDomain category);
        Task<string> RemoveCategory(int ID);
        Task<List<CategoryDomain>> GetAllCategories();
        Task<CategoryDomain> GetCategory(int ID);
    }
    public class CategoryProvider : ICategoryProvider
    {


        public CategoryProvider(MyDbContext db)
        {
            this.db = db;
        }

        public MyDbContext db { get; set; }

        public async Task<List<CategoryDomain>> GetAllCategories()
        {
            return await Task.FromResult(db.categories.ToList());
        }

        public async Task<CategoryDomain> GetCategory(int ID)
        {
            return await Task.FromResult(db.categories.Find(ID));
        }

        public async Task<string> RegisterCategory(CategoryDomain category)
        {
            CategoryDomain categoryDomain = await Task.FromResult(db.categories.Where(x => x.CategoryName == category.CategoryName).FirstOrDefault());
            if (categoryDomain != null)
            {
                return "Category is already present";
            }
            await db.categories.AddAsync(category);
            await db.SaveChangesAsync();
            return "Data has been saved successfully";
        }

        public async Task<string> RemoveCategory(int ID)
        {
            await Task.FromResult(db.categories.Remove(db.categories.Find(ID)));
            await db.SaveChangesAsync();
            return "Data has been removed successfully";
        }

        public async Task<string> UpdateCategory(CategoryDomain category)
        {
            CategoryDomain category1 = await Task.FromResult(db.categories.Where(x => x.CategoryName == category.CategoryName).FirstOrDefault());
            if (category1 != null && category1.CategoryID == category.CategoryID)
            {
                return "Category Name is already exists";
            }
            await Task.FromResult(db.categories.Update(category));
            await db.SaveChangesAsync();
            return "Category has been updated successfully";
        }
    }
}
