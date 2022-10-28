namespace Ecommerce.Shared.Models
{
    public class ProductModel
    {
        public int CategoryID { get; set; }
        public int SubCategoryID { get; set; }
        public int CompanyID { get; set; }
        public string ProductName { get; set; }
        public string MainImage { get; set; }
        public string OtherImages { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Status { get; set; }
    }
}
