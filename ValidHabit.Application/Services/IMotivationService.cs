using ValidHabit.Application.DTOs.Motivation;
using ValidHabit.Application.Utilities;

namespace ValidHabit.Application.Services
{
    public interface IMotivationService
    {
        Task<Result<bool>> HasAnsweredMotivationQuestions(string userId);
        Task<Result<IEnumerable<MotivationQuestionDto>>> GetStandardMotivationQuestionsAsync();
        Task<Result<UserMotivationAnswersDto>> GetUserMotivationAnswersAsync(string userId);
        Task<Result> SetUserMotivationAnswersAsync(UserMotivationAnswersDto userMotivationAnswers);
    }
}
