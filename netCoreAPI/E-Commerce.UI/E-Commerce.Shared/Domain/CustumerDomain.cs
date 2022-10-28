using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Shared.Domain
{
    public class CustumerDomain
    {
        [Key]
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerContact { get; set; }
        public string CustomerPassword { get; set; }
        public string CustomerAddress { get; set; }

    }
}
