using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SkinDesign.Entities;
using SkinDesign.ViewModels;
using System.Threading.Tasks;

namespace SkinDesign.Controllers
{
    public class AccountController : Controller
    {
        private SignInManager<User> _signInManager;
        private UserManager<User> _userManager;

        public AccountController(UserManager<User> userManger, SignInManager<User> signInManager)
        {
            _userManager = userManger;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var loginResult = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);

                if (loginResult.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Could not login.");
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
