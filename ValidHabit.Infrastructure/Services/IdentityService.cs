using Azure.Core;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using ValidHabit.Application.DTOs;
using ValidHabit.Application.Interfaces;
using ValidHabit.Application.Utilities;
using ValidHabit.Domain.Entities;
using ValidHabit.Domain.Primitives;
using ValidHabit.Domain.ValueObjects;

namespace ValidHabit.Infrastructure.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IHabitTrackerDbContext _dbContext;

        public IdentityService(
            IHabitTrackerDbContext dbContext,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<Result> RegisterAsync(UserRegistrationDto user)
        {
            var identityUser = new IdentityUser 
            { 
                UserName = user.Username,
                Email = user.Email,
            };

            var result = await _userManager.CreateAsync(identityUser, user.Password);

            if (result.Succeeded)
            {
                var userProfile = new UserProfile
                {
                    Id = identityUser.Id,
                    FirstName = FirstName.Create(user.FirstName),
                    LastName = LastName.Create(user.LastName)
                };

                _dbContext.UserProfiles.Add(userProfile);
                await _dbContext.SaveChangesAsync(default);

                return Result.Success();
            }

            var errors = result.Errors.Select(e => e.Description);
            return Result.Failure(string.Join(" ", errors));
        }

        public async Task<Result> LoginAsync(UserLoginDto user)
        {
            var result = await _signInManager.PasswordSignInAsync(user.Username, user.Password, false, false);

            if (result.Succeeded)
            {
                return Result.Success();
            }

            return Result.Failure("Authorization was not successful");
        }
    }
}
