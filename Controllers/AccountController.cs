using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProductApplication.Models.Identity;
using ProductApplication.ViewModels;
using System.Threading.Tasks;

namespace ProductApplication.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Password = string.Empty;
                model.ConfirmPassword = string.Empty;
                return View(model);
            }

            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null)
            {
                ModelState.AddModelError(nameof(model.UserName), "Bu kullanıcı adı daha önce sisteme kayıt edilmiştir");
                return View(model);
            }
            user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                ModelState.AddModelError(nameof(model.Email), "Bu email daha önce sisteme kayıt edilmiştir");
                return View(model);
            }

            user = new ApplicationUser()
            {
                UserName = model.UserName,
                Email = model.Email,
                Name = model.Name,
                Surname = model.Surname
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Kayıt işleminde bir hata oluştu");
                return View(model);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, true);

            if (result.Succeeded)
            {
                return RedirectToAction("GetProduct", "Product", new { area = "" });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı adı veya şifre hatalı");
                return View(model);
            }
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

    }
}