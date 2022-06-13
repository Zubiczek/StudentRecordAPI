using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using StudentRecordAPI.Database;
using StudentRecordAPI.Database.Entities;

namespace StudentRecordAPI.ServiceExtensions
{
    public static class IdentityConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services
                .AddIdentity<UserEntity, IdentityRole>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<Context>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.SignIn.RequireConfirmedEmail = true;
            });
        }
    }
}
