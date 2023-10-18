using ValidHabit.Application.DTOs.Authorization;
using ValidHabit.Application.Utilities;

namespace ValidHabit.Application.Interfaces
{
    public interface IAuthenticationService
    {
        Task<Result> RegisterAsync(UserRegistrationDto user);
        Task<Result> LoginAsync(UserLoginDto user);
        Task<Result> ConfirmEmailAsync(string userId, string token);
    }
}
