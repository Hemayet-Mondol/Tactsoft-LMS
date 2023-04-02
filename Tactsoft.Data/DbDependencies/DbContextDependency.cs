using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tactsoft.Core.Identity;

namespace Tactsoft.Service.DbDependencies
{
    public static class DbContextDependency
    {
        public static void AddDbContextDependencies(this IServiceCollection services, IConfiguration configuration)
        {


            var connectionString = configuration.GetConnectionString("DbConnection");
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                options.LogTo(Console.WriteLine);
                options.UseSqlServer(connectionString);
            });

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.User.RequireUniqueEmail = true;
                options.Password.RequireNonAlphanumeric = false;

            }).AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();            

        }
   

    }

}
