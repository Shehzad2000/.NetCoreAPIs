using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Shared.Domain
{
    public class CategoryDomain
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int Status { get; set; }
    }
}
