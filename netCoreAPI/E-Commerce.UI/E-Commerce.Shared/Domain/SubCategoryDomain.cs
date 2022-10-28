using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Shared.Domain
{
    public class SubCategoryDomain
    {
        [Key]
        public int SubCategoryId { get; set; }
        public int CategoryID { get; set; }
        public string SubCategoryName { get; set; }
        public int Status { get; set; }

    }
}
