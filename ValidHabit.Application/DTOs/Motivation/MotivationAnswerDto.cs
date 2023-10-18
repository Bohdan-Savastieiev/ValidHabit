using System.ComponentModel.DataAnnotations;

namespace ValidHabit.Application.DTOs.Motivation
{
    public class MotivationAnswerDto
    {
        [Required(ErrorMessage = "It is required to indicate to which question the answer is.")]
        public int QuestionId { get; }
        [Required(ErrorMessage = "Answer to the question is required.")]
        public string Answer { get; set; }
    }
}