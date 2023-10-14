using ValidHabit.Domain.Primitives;
using ValidHabit.Domain.ValueObjects;

namespace ValidHabit.Domain.Entities
{
    public class HabitTemplate : Entity
    {
        public Name Name { get; set; }
        public string Template { get; set; }
    }
}