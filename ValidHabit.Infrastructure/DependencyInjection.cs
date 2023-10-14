using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ValidHabit.Application.Interfaces;
using ValidHabit.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ValidHabit.Infrastructure.Services;

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

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<HabitTrackerDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IIdentityService, IdentityService>();

            return services;
        }
    }
}