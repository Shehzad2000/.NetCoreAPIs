using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Shared.Domain
{
    public class MyDomains
    {
        public CategoryDomain category { get; set; }
        public SubCategoryDomain subCategory { get; set; }
        public CompanyDomain company { get; set; }
        public AdminDomain admin { get; set; }
        public UserDomain user { get; set; }
        public ProductDomain product { get; set; }
    }
}
