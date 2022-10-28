using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Shared.Domain
{
    public class OrderDomain
    {
        [Key]
        public int OrderID { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }
        public int PostalCode { get; set; }
        public int CustomerID { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }

    }
}
