using System.ComponentModel.DataAnnotations;

namespace CosmeticsShop.Models
{
    public class CartItem
    {
        
        public int Id { get; set; }
        
        public string CartId { get; set; }

        public int Price { get; set; }

        public Cosmetic Cosmetic { get; set; }
    }
}
