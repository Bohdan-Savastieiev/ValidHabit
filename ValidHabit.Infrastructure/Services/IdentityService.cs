using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using ValidHabit.Application.Interfaces;

namespace ValidHabit.Infrastructure.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public IdentityService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<string> CreateAsync(string username, string password)
        {
            var identityUser = new IdentityUser { UserName = username };
            var result = await _userManager.CreateAsync(identityUser, password);

            if (result.Succeeded)
            {
                return "User registered successfully";
            }

            // Aggregate all errors into a single string
            var errors = string.Join(", ", result.Errors.Select(x => x.Description));
            return $"User registration failed: {errors}";
        }

        public async Task<string> LoginAsync(string username, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, false, false);

            if (result.Succeeded)
            {
                return "Logged in successfully";
            }

            if (result.IsLockedOut)
            {
                return "User account is locked out";
            }

            if (result.IsNotAllowed)
            {
                return "User is not allowed to log in";
            }

            return "Invalid username or password";
        }
    }
}
