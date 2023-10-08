namespace ValidHabit.Domain.Entities
{
    public class Habit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }

        public Guid UserId { get; set; }
        public int TimeFrameId { get; set; }

        public virtual UserProfile User { get; set; }
        public virtual HabitTimeFrame TimeFrame { get; set; }
        public virtual ICollection<HabitCategory> Categories { get; set; }
        public virtual ICollection<HabitRecord> Records { get; set; }
    }
}
