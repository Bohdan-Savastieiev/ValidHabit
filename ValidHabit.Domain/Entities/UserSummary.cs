namespace ValidHabit.Domain.Entities
{
    public class UserSummary
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CompletedHabitGoals { get; set; }
        public int TotalHabitGoals { get; set; }
        public double Rating { get; set; }

        public Guid UserId { get; set; }

        public virtual UserProfile User { get; set; }
    }
}