using Microsoft.EntityFrameworkCore;

namespace CosmeticsShop.Models
{
    public class ShopCart
    {
        private readonly CosmeticsShopContext _cosmeticsShopContext;

        public ShopCart(CosmeticsShopContext cosmeticsShopContext)
        {
            _cosmeticsShopContext = cosmeticsShopContext;
        }

        public string ShopCartId { get; set; }
        public List<CartItem> listCartItems { get; set; }   
        
        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<CosmeticsShopContext>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", shopCartId);
            return new ShopCart(context) { ShopCartId = shopCartId}; 
        }

        public void AddToCart(Cosmetic cosmetic)
        {
            _cosmeticsShopContext.CartItems.Add(
                new CartItem
                {
                    CartId = ShopCartId,
                    Cosmetic = cosmetic,
                    Price = cosmetic.Price
                }
                );
           _cosmeticsShopContext.SaveChanges();
        }

        public List<CartItem> GetCartItems()
        {
            return _cosmeticsShopContext.CartItems.Where(c => c.CartId == ShopCartId).Include(s => s.Cosmetic).ToList(); 
        }
    }
}
