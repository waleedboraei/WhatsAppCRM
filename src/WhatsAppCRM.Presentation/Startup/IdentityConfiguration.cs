using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WhatsAppCRM.Infrastructure.Data;

namespace WhatsAppCRM.Presentation.Startup
{
    public static class IdentityConfiguration
    {
        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CrmDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddDefaultTokenProviders();
                //.AddEntityFrameworkStores<CrmDbContext>();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
            });

            return services;
        }
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddAutoMapper(assemblies);

            return services;
        }
    }
}