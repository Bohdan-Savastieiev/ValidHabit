using ValidHabit.Application.DTOs;
using ValidHabit.Application.Utilities;

namespace ValidHabit.Application.Interfaces
{
    public interface IIdentityService
    {
        Task<Result> RegisterAsync(UserRegistrationDto user);
        Task<Result> LoginAsync(UserLoginDto user);
    }

}
