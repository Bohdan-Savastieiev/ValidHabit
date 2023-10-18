using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ValidHabit.Application.Interfaces;
using ValidHabit.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using ValidHabit.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using ValidHabit.Infrastructure.ServiceConfigurations;
using ValidHabit.Infrastructure.ServiceSettings;

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

            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.Configure<IdentitySettings>(configuration.GetSection("IdentitySettings"));


            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 0;
                options.SignIn.RequireConfirmedAccount = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            });

            services.AddScoped<IEmailService, EmailService>();
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            return services;
        }
    }
}