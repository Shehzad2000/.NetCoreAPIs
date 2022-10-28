using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Shared.Domain
{
    public class UserDomain
    {
        [Key]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserContact { get; set; }
        public string UserPassword { get; set; }
        public int UserGender { get; set; }
        public string UserImage { get; set; }
        public string UserCNIC { get; set; }
        public string UserAddress { get; set; }
        public int UserStatus { get; set; }
        public int CreatedBy { get; set; }
        public DateTime RegisterationDate { get; set; }
    }
}
