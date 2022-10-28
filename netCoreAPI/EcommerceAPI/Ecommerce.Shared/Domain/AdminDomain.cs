using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Shared.Domain
{
    public class AdminDomain
    {
        [Key]
        public int AdminID { get; set; }
        public string AdminName { get; set; }
        public string AdminEmail { get; set; }
        public string AdminContact { get; set; }
        public string AdminPassword { get; set; }
        public int AdminGender { get; set; }
        public string AdminImage { get; set; }
        public int AdminStatus { get; set; }
        public DateTime RegisterationDate { get; set; }
    }
}
