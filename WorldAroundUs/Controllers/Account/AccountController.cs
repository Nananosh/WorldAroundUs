using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorldAroundUs.BlueLife;
using WorldAroundUs.Migrations;
using WorldAroundUs.Models;
using WorldAroundUs.ViewModels;
using WorldAroundUs.ViewModels.Account;

namespace WorldAroundUs.Controllers.Account
{
    public class AccountController : Controller
    {
        private readonly ApplicationContext _database;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager,
            ApplicationContext context)
        {
            _database = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        
        public async Task<string> GetUserImage(string id)
        {
            var user = await _database.Users.SingleOrDefaultAsync(u => u.Id == id);
            return user.UserImageUrl;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult EditUserImageUrl()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult EditUserImageUrl(UserImage model)
        {
            var userId = User.Claims.ElementAt(0).Value;
            var user = _database.Users.FirstOrDefault(x => x.Id == userId);
            user.UserImageUrl = model.UserImageUrl;
            _database.SaveChanges();
            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Email = model.Email, UserName = model.UserName,
                    UserImageUrl = "https://img.icons8.com/material-outlined/200/000000/user--v1.png"
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors) ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel {ReturnUrl = returnUrl});
        }

        public async Task SendEmail(string userName)
        {
            var user = _database.Users.FirstOrDefault(x => x.UserName == userName);
            EmailConfirm emailService = new EmailConfirm();
            await emailService.SendEmailDefault(user.Email, "Вход на сайт",
                $"Пользователль {user.UserName} приступил к обучению.");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var signInResult = await _signInManager
                    .PasswordSignInAsync(model.UserName, model.Password, true, false);
                if (signInResult.Succeeded)
                {
                    await SendEmail(model.UserName);
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                        return Redirect(model.ReturnUrl);

                    await _database.SaveChangesAsync();
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Incorrect username or password");
            }

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}