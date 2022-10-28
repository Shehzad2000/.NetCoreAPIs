using Ecommerce.Core.Data;
using Ecommerce.Shared.Domain;

namespace Ecommerce.Core.Providers
{
    public interface IWishListProvider
    {
        Task<string> AddProductToWishList(WishListDomain product);
        Task<string> DeleteProductFromWishList(int ID);
        Task<List<MyDomains>> GetWishListProduct(int ID);

    }
    public class WishListProvider : IWishListProvider
    {
        private readonly MyDbContext db;

        public WishListProvider(MyDbContext db)
        {
            this.db = db;
        }
        public async Task<string> AddProductToWishList(WishListDomain product)
        {
            WishListDomain wishList = await db.wishLists.FindAsync(product.WishListID);
            if (wishList != null)
                return "WishList is already present";
            await db.wishLists.AddAsync(product);
            await db.SaveChangesAsync();
            return "Product has been added to wishlist successfully";
        }

        public async Task<string> DeleteProductFromWishList(int ID)
        {
            await Task.FromResult(db.wishLists.Remove(db.wishLists.Find(ID)));
            await db.SaveChangesAsync();
            return "Product has been removed from wishlist successfully";
        }

        public async Task<List<MyDomains>> GetWishListProduct(int ID)
        {
            var list = await Task.FromResult((from w in db.wishLists
                                              join cu in db.customers on w.CustomerID equals cu.CustomerID
                                              join p in db.products on w.ProductID equals p.ProductID
                                              where cu.CustomerID==ID
                                              select new MyDomains
                                              {
                                                  wishList = w,
                                                  product = p,
                                                
                                              }).ToList());
            return list;
                                              
        }
    }
}
