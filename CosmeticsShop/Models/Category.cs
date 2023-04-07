namespace CosmeticsShop.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public List<Cosmetic>? Cosmetics { get; set; }

        public string Image { get; set; }
    }
}
