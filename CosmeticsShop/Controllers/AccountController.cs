using CosmeticsShop.Models;
using CosmeticsShop.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CosmeticsShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly CosmeticsShopContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
       private readonly RoleManager<IdentityRole> _roleManager;
        
        public AccountController(CosmeticsShopContext db, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager) 
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager; 
           
        }

        public ActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]  
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                ApplicationUser user = new ApplicationUser { UserName = model.Email };
                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var defaultrole = _roleManager.FindByNameAsync("Buyer").Result;

                    if (defaultrole != null)
                    {
                        IdentityResult roleresult = await _userManager.AddToRoleAsync(user, defaultrole.Name);
                    }

                    return RedirectToAction("Index");
                }

                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                    ModelState.AddModelError("", error.Description);
                    }
                    return View(model); 
                }
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
               
                var result =
                    await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent:true, lockoutOnFailure:false);
                if (result.Succeeded)
                {

                        return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "There is somrthing wrong with your email and/ or password");
                }
            }
            return View(model);
        }

        [HttpPost]

        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }



    }
}
