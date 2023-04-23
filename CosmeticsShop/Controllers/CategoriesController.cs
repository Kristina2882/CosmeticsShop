using CosmeticsShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CosmeticsShop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoriesController : Controller
    {
        private readonly CosmeticsShopContext _db;

        public CategoriesController(CosmeticsShopContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Category> categories  = _db.Categories.ToList();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category) 
        {
            _db.Categories.Add(category);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [AllowAnonymous]
        public IActionResult Details (int id)
        {
            Category category = _db.Categories
                .Include(c => c.Cosmetics)
                .FirstOrDefault(c => c.CategoryId == id);
            return View(category);
        }

        public IActionResult Edit (int id)
        {
            Category category = _db.Categories.FirstOrDefault(c => c.CategoryId == id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category) 
        {
            _db.Categories.Update(category);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Category category = _db.Categories.FirstOrDefault(c => c.CategoryId == id);
            return View(category);
        }

        [HttpPost, ActionName("Delete")]    
        public IActionResult DeleteConfirmed(int id)
        {
            Category category = _db.Categories.FirstOrDefault(c => c.CategoryId == id);
            _db.Categories.Remove(category);    
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
