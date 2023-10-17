using ValidHabit.Domain.Primitives;
using ValidHabit.Domain.ValueObjects;

namespace ValidHabit.Domain.Entities
{
    public class UserProfile : Entity
    {
        public new string Id { get; init; }
        public FirstName FirstName { get; set; }
        public LastName LastName { get; set; }

        public DateTimeOffset CreationDate { get; }

        public virtual ICollection<MotivationAnswer> MotivationAnswers { get; set; }
        public virtual ICollection<Habit> Habits { get; set; }
        public virtual ICollection<UserSummary> Summaries { get; set; }
    }
}
