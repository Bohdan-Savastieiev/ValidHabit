using Microsoft.AspNetCore.Mvc;
using ValidHabit.Application.DTOs;
using ValidHabit.Application.Interfaces;

namespace ValidHabit.WebUI.Controllers
{
    public class UserController : Controller
    {
        private readonly IIdentityService _identityService;

        public UserController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegistrationDto user)
        {
            var result = await _identityService.RegisterAsync(user);
            if (result.IsSuccess)
            {
                return RedirectToAction("Login");
            }
            ModelState.AddModelError(string.Empty, result.ErrorMessage);
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto user)
        {
            var result = await _identityService.LoginAsync(user);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError(string.Empty, result.ErrorMessage);
            return View(user);
        }
    }
}
