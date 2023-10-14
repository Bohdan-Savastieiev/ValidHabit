using ValidHabit.Domain.Primitives;

namespace ValidHabit.Domain.Entities
{
    public class MotivationAnswer : Entity
    {
        public string Answer { get; set; }
        
        public string UserId { get; init; }
        public virtual UserProfile User { get; init; }

        public int QuestionId { get; init; }
        public virtual MotivationQuestion Question { get; init; }
    }
}
