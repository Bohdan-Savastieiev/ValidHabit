namespace ValidHabit.Domain.Entities
{
    public class HabitCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Habit> Habits { get; set; }
    }
}
