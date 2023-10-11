using ValidHabit.Domain.Primitives;
using ValidHabit.Domain.ValueObjects;

namespace ValidHabit.Domain.Entities
{
    public class HabitCategory : Entity
    {
        public Name Name { get; set; }

        public virtual ICollection<HabitAndCategory> Habits { get; set; }
    }
}
