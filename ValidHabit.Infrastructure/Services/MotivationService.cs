
using ValidHabit.Application.DTOs.Motivation;
using ValidHabit.Application.Services;
using ValidHabit.Application.Utilities;

namespace ValidHabit.Infrastructure.Services
{
    public class MotivationService : IMotivationService
    {
        public Task<Result<IEnumerable<MotivationQuestionDto>>> GetStandardMotivationQuestionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Result<UserMotivationAnswersDto>> GetUserMotivationAnswersAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> HasAnsweredMotivationQuestions(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<Result> SetUserMotivationAnswersAsync(UserMotivationAnswersDto userMotivationAnswers)
        {
            throw new NotImplementedException();
        }
    }
}