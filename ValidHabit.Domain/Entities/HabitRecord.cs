using ValidHabit.Domain.Primitives;

namespace ValidHabit.Domain.Entities
{
    public class HabitRecord : Entity
    {
        public bool IsCompleted { get; set; }

        public DateTimeOffset CreationDate{ get; }

        public int HabitId { get; init; }
        public virtual Habit Habit { get; init; }
    }
}