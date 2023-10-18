using System.ComponentModel.DataAnnotations;

namespace ValidHabit.Application.DTOs.Motivation
{
    public class UserMotivationAnswersDto
    {
        [Required(ErrorMessage = "UserId is required.")]
        public string UserId { get; }
        [Required(ErrorMessage = "Motivation Answers are required.")]
        public IEnumerable<MotivationAnswerDto> MotivationAnswers { get; set; }
    }
}