namespace ValidHabit.Domain.Entities
{
    public class UserSummary
    {
        public int Id { get; set; }
        public int CompletedHabitGoals { get; set; }
        public int TotalHabitGoals { get; set; }
        public double Rating { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Guid UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}