using ValidHabit.Domain.Primitives;

namespace ValidHabit.Domain.Entities
{
    public class MotivationAnswer : Entity
    {
        public string Answer { get; set; }
        
        public int UserId { get; init; }
        public virtual ApplicationUser User { get; init; }

        public int QuestionId { get; init; }
        public virtual MotivationQuestion Question { get; init; }
    }
}
