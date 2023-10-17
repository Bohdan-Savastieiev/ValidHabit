using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using ValidHabit.Application.DTOs;
using ValidHabit.Application.Interfaces;
using ValidHabit.Application.Utilities;
using ValidHabit.Domain.Entities;
using ValidHabit.Domain.Primitives;
using ValidHabit.Domain.ValueObjects;
using ValidHabit.Infrastructure.ServiceSettings;

namespace ValidHabit.Infrastructure.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IHabitTrackerDbContext _dbContext;
        private readonly IEmailService _emailService;
        private readonly IdentitySettings _identitySettings;

        public IdentityService(
            IHabitTrackerDbContext dbContext,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IEmailService emailService,
            IOptions<IdentitySettings> identitySettings)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailService = emailService;
            _identitySettings = identitySettings.Value;
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
                await SendConfirmationEmailAsync(identityUser.Id);

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

        public async Task<Result> ConfirmEmailAsync(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return Result.Failure("User not found.");
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);
            return result.Succeeded 
                ? Result.Success() 
                : Result.Failure("Email confirmation failed.");
        }

        private async Task<Result> SendConfirmationEmailAsync(string userId)
        {
            // Generate email confirmation token
            var user = await _userManager.FindByIdAsync(userId);
            if (user is null)
            {
                return Result.Failure("User not found.");
            }

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            // Generate confirmation link
            var confirmationLink = QueryHelpers.AddQueryString($"{_identitySettings.BaseUrl}/Account/ConfirmEmail",
                new Dictionary<string, string?>
                {
                    {"userId", user.Id },
                    {"token", token }
                });

            // Send confirmation email
            var emailDto = new EmailDto
            {
                To = user.Email,
                Subject = "Confirm your email",
                Body = $"Please confirm your email by clicking <a href='{HtmlEncoder.Default.Encode(confirmationLink)}'>here</a>."
            };
            await _emailService.SendEmailAsync(emailDto);

            return Result.Success();
        }
    }
}
