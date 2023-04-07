using System.ComponentModel;

namespace CosmeticsShop.Models
{
    public class Cosmetic
    {
        public int CosmeticId { get; set; } 
        public string Name { get; set; }
        public int Price { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public Category? Category { get; set; }
        public int CategoryId { get; set; } 
    }
}
