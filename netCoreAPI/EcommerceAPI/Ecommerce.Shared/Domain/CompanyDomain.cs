using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Shared.Domain
{
    public class CompanyDomain
    {
        [Key]
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public int Status { get; set; }
    }
}
