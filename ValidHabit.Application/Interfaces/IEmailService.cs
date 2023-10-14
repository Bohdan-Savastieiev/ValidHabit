using ValidHabit.Application.DTOs;
using ValidHabit.Application.Utilities;

namespace ValidHabit.Application.Interfaces
{
    public interface IEmailService
    {
        Task<Result> SendEmailAsync(EmailDto request);
    }
}