using ValidHabit.Domain.Primitives;

namespace ValidHabit.Domain.Entities
{
    public class MotivationQuestion : Entity
    {
        public string Question { get; set; }

        public virtual ICollection<MotivationAnswer> Answers { get; set; }
    }
}
