using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Shared.Domain
{
    public class PaymentDomain
    {
        [Key]
        public int PaymentId { get; set; }
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public int PaymentType { get; set; }
        public string CardNumber { get; set; }
        public int CVC { get; set; }
        public string CardHolderName { get; set; }
        public DateTime ValidThrough { get; set; }
        public int status { get; set; }
        public string AccountNo { get; set; }
    }
}
