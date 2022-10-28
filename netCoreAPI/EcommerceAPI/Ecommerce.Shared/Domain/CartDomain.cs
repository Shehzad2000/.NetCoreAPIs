using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Shared.Domain
{
    public class CartDomain
    {
     [Key]
     public int CartID { get; set; } 
     public int ProductID { get; set; }
     public int Quantity { get; set; }   
     public int PricePerUnit { get; set; }   
     public int CustomerID { get; set; }   


    }
}
