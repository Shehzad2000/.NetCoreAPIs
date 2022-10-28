using Ecommerce.Core.Data;
using Ecommerce.Shared.Domain;

namespace Ecommerce.Core.Providers
{
    public interface IProductProvider
    {
        Task<string> AddProduct(ProductDomain product);
        Task<string> UpdateProduct(ProductDomain product);
        Task<string> DeleteProduct(int ID);
        Task<ProductDomain> GetProductById(int ID);
        Task<List<MyDomains>> GetAllProducts();
        Task<List<MyDomains>> GetProductsByID(ProductDomain productDomain);

    }
    public class ProductProvider : IProductProvider
    {
        private readonly MyDbContext db;

        public ProductProvider(MyDbContext db)
        {
            this.db = db;
        }

        public async Task<string> AddProduct(ProductDomain product)
        {
            ProductDomain p = await Task.FromResult(db.products.Where(x => x.ProductName == product.ProductName).FirstOrDefault());
            if (p != null)
            {
                return "Product is already exist";
            }
            await db.products.AddAsync(product);
            db.SaveChanges();
            return "Product has been added successfully";
        }

        public async Task<string> DeleteProduct(int ID)
        {
            await Task.FromResult(db.products.Remove(db.products.Find(ID)));
            await db.AddRangeAsync();
            return "Data has been removed successfully";
        }

        public async Task<List<MyDomains>> GetAllProducts()
        {
            var list = await Task.FromResult((from d in db.products
                                              join c in db.categories on d.CategoryID equals c.CategoryID
                                              join s in db.subCategories on d.SubCategoryID equals s.SubCategoryId
                                              join co in db.companies on d.CompanyID equals co.CompanyID
                                              select new MyDomains
                                              {
                                                  product = d,
                                                  category = c,
                                                  subCategory = s,
                                                  company = co,
                                              }).ToList());
            return list;/*await Task.FromResult(db.products.ToList())*/;
        }

        public async Task<ProductDomain> GetProductById(int ID)
        {
            return await db.products.FindAsync(ID);
        }
        public async Task<List<MyDomains>> GetProductsByID(ProductDomain productDomain)
       {
            int? CatID = productDomain.CategoryID != 0 ? productDomain.CategoryID : null;
            int? CompID = productDomain.CompanyID != 0 ? productDomain.CompanyID : null;
            int? BrandId = productDomain.BrandID != 0 ? productDomain.BrandID : null;
            return await Task.FromResult(await Task.FromResult((from d in db.products
                                                               join c in db.categories on d.CategoryID equals c.CategoryID
                                                               join s in db.subCategories on d.SubCategoryID equals s.SubCategoryId
                                                               join co in db.companies on d.CompanyID equals co.CompanyID
                                                               join b in db.brands on d.BrandID equals b.BrandID
                                                               select new MyDomains
                                                               {
                                                                   product = d,
                                                                   category = c,
                                                                   subCategory = s,
                                                                   company = co,
                                                                   brand=b,
                                                               }).Where(x=>x.category.CategoryID==CatID||x.company.CompanyID==CompID||x.brand.BrandID==BrandId).ToList()));
        }

        public async Task<string> UpdateProduct(ProductDomain product)
        {
            ProductDomain p = await Task.FromResult(db.products.Where(x => x.ProductName == product.ProductName).FirstOrDefault());
            if (p != null)
            {
                return "Product is already exists";
            }
            await Task.FromResult(db.products.Update(product));
            await db.SaveChangesAsync();
            return "Data has been updated successfully";
        }
    }
}
