using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Shared.Domain
{
    public class WishListDomain
    {
        [Key]
        public int WishListID { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public DateTime Date { get; set; }
    }
}
