
using CosmeticsShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CosmeticsShop.Controllers
{
    
    public class OrderController : Controller
    {

        private readonly CosmeticsShopContext _db;
        private readonly ShopCart _shopCart;

        public OrderController(CosmeticsShopContext db, ShopCart shopCart)
        {
            _db = db;
            _shopCart = shopCart;
        }

        public IActionResult CheckOut()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckOut(Order order)
        {
            var items = _shopCart.GetCartItems().ToList();
            if(items.Count == 0)
            {
                return View("Empty");
                
            }

            if(ModelState.IsValid)
            {
                order.OrderDate = DateTime.Now;
                _db.Orders.Add(order);
                _db.SaveChanges();

                foreach (var item in items)
                    {
                        _db.OrderDetails.Add(new OrderDetail() { OrderId = order.OrderId, CosmeticId = item.Cosmetic.CosmeticId, Price = item.Cosmetic.Price});
                        _db.SaveChanges();
                    }
                    
               
                return RedirectToAction("Complete");
            }
            
            return View(order);

        }
        
        public IActionResult Complete()
        {
            ViewBag.Message = "Your order is processed successfully:))";
            return View();
        }
    }
}
