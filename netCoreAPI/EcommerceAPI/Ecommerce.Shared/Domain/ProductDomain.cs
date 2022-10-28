using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Shared.Domain
{
    public class ProductDomain
    {
        [Key]
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public int SubCategoryID { get; set; }
        public int CompanyID { get; set; }
        public int AdminID { get; set; }
        public int UserID { get; set; }
        public int BrandID { get; set; }
        public string ProductName { get; set; }
        public string MainImage { get; set; }
        public string OtherImages { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Status { get; set; }
    }
}
