using CosmeticsShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CosmeticsShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly CosmeticsShopContext _db;

        public HomeController(CosmeticsShopContext db)
        {
            _db = db;   
        }
        public IActionResult Index()
        {
            Category[] categories = _db.Categories.ToArray();
            Cosmetic[] cosmetics = _db.Cosmetics.ToArray();
            Dictionary<string, object[]> model = new Dictionary<string, object[]>();
            model.Add("category", categories);
            model.Add("cosmetic", cosmetics);

            return View(model);
        }

    }
}