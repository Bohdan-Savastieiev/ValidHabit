using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ValidHabit.Application.DTOs;
using ValidHabit.Application.Interfaces;

namespace ValidHabit.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IIdentityService _identityService;

        public AccountController(IIdentityService identityService)
        {
            _identityService = identityService;
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
                var result = await _identityService.RegisterAsync(model);
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
            var result = await _identityService.ConfirmEmailAsync(userId, token);
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
