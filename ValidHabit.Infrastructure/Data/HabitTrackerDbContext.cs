using Microsoft.EntityFrameworkCore;
using ValidHabit.Application.Interfaces;
using ValidHabit.Domain.Entities;

namespace ValidHabit.Infrastructure.Data
{
    public class HabitTrackerDbContext : DbContext, IHabitTrackerDbContext
    {
        public HabitTrackerDbContext(DbContextOptions options) : base(options) { }

        public HabitTrackerDbContext() { }
        public DbSet<Habit> Habits { get; set; }
        public DbSet<HabitCategory> HabitCategories { get; set; }
        public DbSet<HabitRecord> HabitRecords { get; set; }
        public DbSet<HabitTemplate> HabitTemplates { get; set; }
        public DbSet<HabitExecutionFrequency> HabitExecutionFrequencies { get; set;}
        public DbSet<MotivationAnswer> MotivationAnswers { get; set;}
        public DbSet<MotivationQuestion> MotivationQuestions { get; set;}
        public DbSet<ApplicationUser> UserProfiles { get; set; }
        public DbSet<UserSummary> UserSummaries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HabitTrackerDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}