namespace Ecommerce.Shared.Models
{
    public class PaymentModel
    {
        public int PaymentType { get; set; }
        public string CardNumber { get; set; }
        public int CVC { get; set; }
        public string CardHolderName { get; set; }
        public DateTime ValidThrough { get; set; }
        public int status { get; set; }
        public string AccountNo { get; set; }
    }
}
