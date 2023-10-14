using Microsoft.EntityFrameworkCore;
using ValidHabit.Domain.Entities;

namespace ValidHabit.Application.Interfaces
{
    public interface IHabitTrackerDbContext : IDisposable
    {
        public DbSet<Habit> Habits { get; set; }
        public DbSet<HabitCategory> HabitCategories { get; set; }
        public DbSet<HabitRecord> HabitRecords { get; set; }
        public DbSet<HabitTemplate> HabitTemplates { get; set; }
        public DbSet<HabitExecutionFrequency> HabitExecutionFrequencies{ get; set; }
        public DbSet<MotivationAnswer> MotivationAnswers { get; set; }
        public DbSet<MotivationQuestion> MotivationQuestions { get; set; }
        public DbSet<User> UserProfiles { get; set; }
        public DbSet<UserSummary> UserSummaries { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
