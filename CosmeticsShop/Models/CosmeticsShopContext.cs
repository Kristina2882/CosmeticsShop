using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CosmeticsShop.Models
{
    public class CosmeticsShopContext : IdentityDbContext<ApplicationUser>  
    {
        public DbSet<Cosmetic> Cosmetics { get; set; }  
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }    

        public DbSet<Category> Categories { get; set; } 
        

        public CosmeticsShopContext(DbContextOptions options) : base(options) { }
    }
}
