namespace ValidHabit.Domain.Entities
{
    public class ApplicationUser
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual ICollection<MotivationAnswer> MotivationAnswers { get; set; }
        public virtual ICollection<Habit> Habits { get; set; }
        public virtual ICollection<UserSummary> Summaries { get; set; }
    }
}
