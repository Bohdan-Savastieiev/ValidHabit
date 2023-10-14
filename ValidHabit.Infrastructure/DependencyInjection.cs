using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ValidHabit.Application.Interfaces;
using ValidHabit.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using ValidHabit.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;

namespace ValidHabit.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HabitTrackerDbContext>(options =>
            {
                options.UseSqlServer(configuration["ConnectionStrings:LocalDbSqlServer"]);
            });

            services.AddScoped<IHabitTrackerDbContext, HabitTrackerDbContext>();

            services.AddIdentityCore<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<HabitTrackerDbContext>();


            services.AddScoped<IIdentityService, IdentityService>();

            return services;
        }
    }
}