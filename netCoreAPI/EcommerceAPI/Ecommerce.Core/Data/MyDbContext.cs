using Ecommerce.Shared.Domain;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Core.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
        public DbSet<AdminDomain> admins { get; set; }
        public DbSet<CategoryDomain> categories { get; set; }
        public DbSet<SubCategoryDomain> subCategories { get; set; }
        public DbSet<ProductDomain> products { get; set; }
        public DbSet<UserDomain> users { get; set; }
        public DbSet<CompanyDomain> companies { get; set; }
        public DbSet<CustumerDomain> customers { get; set; }
        public DbSet<OrderDetailDomain> orderDetails { get; set; }
        public DbSet<OrderDomain> orders { get; set; }
        public DbSet<PaymentDomain> payment { get; set; }
        public DbSet<WishListDomain> wishLists { get; set; }
        public DbSet<BrandDomain> brands { get; set; }
        public DbSet<CartDomain> carts { get; set; }

    }
}
