using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace CosmeticsShop.Models
{
    public class Order
    {
        
        public int OrderId { get; set; }
       
        
        public string Name { get; set; }
        
        
        [Display(Name = "Surname")]
        public string SurName { get; set; }
        
        
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail")]
        public string Address { get; set; }
        
        public string Phone { get; set; }

        public DateTime OrderDate { get; set; }
        public List<OrderDetail>? OrderDetails { get; set; } 
    }
}
