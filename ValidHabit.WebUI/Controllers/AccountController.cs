using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ValidHabit.Application.DTOs.Authorization;
using ValidHabit.Application.Interfaces;

namespace ValidHabit.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticationService _authService;

        public AccountController(IAuthenticationService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto user)
        {
            var result = await _authService.LoginAsync(user);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError(string.Empty, result.ErrorMessage);
            return View(user);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout(UserLoginDto user)
        {
            var result = await _authService.LoginAsync(user);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError(string.Empty, result.ErrorMessage);
            return View(user);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegistrationDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.RegisterAsync(model);
                if (result.IsSuccess)
                {
                    return RedirectToAction("EmailConfirmation");
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult EmailConfirmation()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            var result = await _authService.ConfirmEmailAsync(userId, token);
            if (result.IsSuccess)
            {
                return View("EmailConfirmed");
            }
            return View("Error");
        }

        [HttpGet]
        public IActionResult EmailConfirmed()
        {
            return View();
        }

    }
}
