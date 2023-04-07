using CosmeticsShop.Models;
using CosmeticsShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;

namespace CosmeticsShop.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly CosmeticsShopContext _db;
        private readonly ShopCart _shopCart;

        public ShopCartController(CosmeticsShopContext db, ShopCart shopCart)
        {
            _db = db;
            _shopCart = shopCart;
        }

        public ViewResult Index()
        {
            var items = _shopCart.GetCartItems();
            _shopCart.listCartItems = items;

            var obj = new ShopCartViewModel
            {
                shopCart = _shopCart,
            };

            return View(obj);
        }

        public RedirectToActionResult AddToCart(int id)
        {
            var item = _db.Cosmetics.FirstOrDefault(i => i.CosmeticId == id);
            if (item != null)
            {
                _shopCart.AddToCart(item);
            }
            return RedirectToAction("Index");
        }


    }
}
