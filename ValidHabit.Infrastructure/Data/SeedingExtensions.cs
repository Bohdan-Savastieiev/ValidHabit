using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using ValidHabit.Domain.Entities;

namespace ValidHabit.Infrastructure.Data
{
    public static class SeedingExtensions
    {
        public static void DatabaseEnsureCreated(this IApplicationBuilder applicationBuilder)
        {
            using (var scope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<HabitTrackerDbContext>();
                var database = dbContext.Database;

                database.EnsureDeleted();
                database.EnsureCreated();

                SeedData(dbContext);
            }
        }

        private static void SeedData(HabitTrackerDbContext dbContext)
        {
            if (!dbContext.MotivationQuestions.Any())
            {
                var questions = new List<MotivationQuestion>
                {
                    new MotivationQuestion { Question = "What is your main goal?"},
                    new MotivationQuestion { Question = "What feeling makes you want to change something in your life?"}
                };

                dbContext.MotivationQuestions.AddRange(questions);
                dbContext.SaveChanges();
            }
        }
    }
}