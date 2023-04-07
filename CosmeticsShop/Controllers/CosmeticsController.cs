using CosmeticsShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CosmeticsShop.Controllers
{
    
    public class CosmeticsController : Controller
    {
        private readonly CosmeticsShopContext _db;

        public CosmeticsController(CosmeticsShopContext db)
        {
            _db = db;   
        }

        public IActionResult Index(string searchString)
        {
            List<Cosmetic> cosmetics = _db.Cosmetics
                .Include(c => c.Category)
                .ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                cosmetics = cosmetics
                    .Where(c => c.Name!.Contains(searchString))
                    .ToList();
            }
            return View(cosmetics);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult Create(Cosmetic cosmetic)
        {
            _db.Cosmetics.Add(cosmetic);    
            _db.SaveChanges();  
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Cosmetic thisCosmetic = _db.Cosmetics
                                    .Include(cosmetic => cosmetic.Category)
                                    .FirstOrDefault(cosmetic => cosmetic.CosmeticId == id);
            return View(thisCosmetic);
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            Cosmetic thisCosmetic = _db.Cosmetics.FirstOrDefault(cosmetic => cosmetic.CosmeticId == id);
            ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
            return View(thisCosmetic);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(Cosmetic cosmetic)
        {
            _db.Cosmetics.Update(cosmetic);
            _db.SaveChanges(true);
            return RedirectToAction("Index");   
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            Cosmetic thisCosmetic = _db.Cosmetics.FirstOrDefault(cosmetic => cosmetic.CosmeticId == id);
            return View(thisCosmetic);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Cosmetic thisCosmetic = _db.Cosmetics.FirstOrDefault(cosmetic => cosmetic.CosmeticId == id);
            _db.Cosmetics.Remove(thisCosmetic);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
