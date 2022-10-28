using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Shared.Domain
{
    public class OrderDetailDomain
    {
        [Key]
        public int OrderDetailID { get; set; }
        public int ProductID { get; set; }
        public int CustomerID { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
