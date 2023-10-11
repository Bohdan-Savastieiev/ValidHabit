using Microsoft.Extensions.DependencyInjection;
using ValidHabit.Application.Interfaces;
using ValidHabit.Infrastructure.Data;

namespace ValidHabit.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IHabitTrackerDbContext, HabitTrackerDbContext>();

            return services;
        }
    }
}