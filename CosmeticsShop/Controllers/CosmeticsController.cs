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
        
        public async Task<ActionResult> Index(string searchString)
        {
            List<Cosmetic> cosmetics = await _db.Cosmetics
                .Include(c => c.Category)
                .ToListAsync(); 

            if (!String.IsNullOrEmpty(searchString))
            {
                var filtered = cosmetics.Where(c => c.Name.Contains(searchString));
                return View(filtered.ToList());
            }

            return View(cosmetics);
        }

        [Authorize(Roles = "Admin")]

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
            return View();
        }
        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            Cosmetic thisCosmetic = _db.Cosmetics.FirstOrDefault(cosmetic => cosmetic.CosmeticId == id);
            ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
            return View(thisCosmetic);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Edit(Cosmetic cosmetic)
        {
            _db.Cosmetics.Update(cosmetic);
            _db.SaveChanges(true);
            return RedirectToAction("Index");   
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            Cosmetic thisCosmetic = _db.Cosmetics.FirstOrDefault(cosmetic => cosmetic.CosmeticId == id);
            return View(thisCosmetic);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Cosmetic thisCosmetic = _db.Cosmetics.FirstOrDefault(cosmetic => cosmetic.CosmeticId == id);
            if (thisCosmetic != null)
            {
                _db.Cosmetics.Remove(thisCosmetic);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();  
            }
        }
    }
}
