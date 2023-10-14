using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;


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
            }
        }
    }
}