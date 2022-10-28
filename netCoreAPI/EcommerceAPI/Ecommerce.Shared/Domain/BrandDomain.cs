using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Shared.Domain
{
    public class BrandDomain
    {
        [Key]
        public int BrandID { get; set; }
        public string BrandName { get; set; }
        public int BrandStatus { get; set; }
    }
}
