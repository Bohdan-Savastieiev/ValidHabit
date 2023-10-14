using ValidHabit.Domain.Primitives;

namespace ValidHabit.Domain.Entities
{
    public class UserSummary : Entity
    {
        public int CompletedHabitGoals { get; init; }
        public int TotalHabitGoals { get; init; }
        public double Rating { get; init; }

        public DateTimeOffset StartDate { get; init; }
        public DateTimeOffset EndDate { get; init; }

        public string UserId { get; init; }
        public virtual UserProfile User { get; init; }
    }
}