using Ecommerce.Core.Data;
using Ecommerce.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Providers
{

    public interface ICartProvider
    {
        Task<string> AddProductToCart(CartDomain cartDomain);
        Task<string> DeleteProduct(int ID);
        Task<string> UpdateProduct(int ID, bool check);
        Task<List<MyDomains>> GetCartProducts();

    }
    public class CartProvider : ICartProvider
    {
        public CartProvider(MyDbContext db)
        {
            this.db = db;
        }

        public MyDbContext db { get; }



        public async Task<string> AddProductToCart(CartDomain cartDomain)
        {
            CartDomain cartDomain1 = await Task.FromResult(db.carts.Where(x => x.ProductID == cartDomain.ProductID).FirstOrDefault());
            if (cartDomain1 != null)
                return "Product is already present in the cart";
            ProductDomain product= await Task.FromResult(db.products.Where(x => x.ProductID == cartDomain.ProductID).FirstOrDefault());
            cartDomain.PricePerUnit = product.Price;
            await db.carts.AddAsync(cartDomain);
            await db.SaveChangesAsync();
            return "Product has been added to cart successfully";
        }

        public async Task<string> DeleteProduct(int ID)
        {
            await Task.FromResult(db.carts.Remove(db.carts.Find(ID)));
            await db.SaveChangesAsync();
            return "Item has been successfully deleted from cart";
        }

        public async Task<string> UpdateProduct(int ID, bool check)
        {
            CartDomain cartDomain = await db.carts.FindAsync(ID);
            ProductDomain product = await db.products.FindAsync(cartDomain.ProductID);
            cartDomain.PricePerUnit = product.Price;
            if (check == true)
                cartDomain.Quantity++;
            else if (check == false && cartDomain.Quantity > 0)
                cartDomain.Quantity--;
            await Task.FromResult(db.carts.Update(cartDomain));
            await db.SaveChangesAsync();
            
            return "Cart has been updated successfully";

        }
         
         
        
        public async Task<List<MyDomains>> GetCartProducts()
        {
            return await Task.FromResult((from p in db.products
                                          join c in db.carts on p.ProductID equals c.CartID
                                          select new MyDomains
                                          {
                                              product = p,
                                              cart = c
                                          }).ToList());
        }


    }
}
