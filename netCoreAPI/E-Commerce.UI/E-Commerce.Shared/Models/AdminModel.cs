using Microsoft.AspNetCore.Http;

namespace Ecommerce.Shared.Models
{
    public class AdminModel
    {
        public int AdminID { get; set; }
        public string AdminName { get; set; }
        public string AdminEmail { get; set; }
        public string AdminContact { get; set; }
        public string AdminPassword { get; set; }
        public int AdminGender { get; set; }
        public IFormFile[] MyImage { get; set; }
        public int AdminStatus { get; set; }
        public DateTime RegisterationDate { get; set; }
    }
}
