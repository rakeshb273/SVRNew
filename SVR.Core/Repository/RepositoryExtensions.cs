 
using Microsoft.Extensions.DependencyInjection;
using SVR.Core.Repository.Interface;
using SVR.Data; 
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration; 

namespace SVR.Core.Repository
    
{
   public static class RepositoryExtensions
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {

            //TODO
            //add packages Microsoft.Extensions.Configuration.Binder and Microsoft.EntityFrameworkCore.InMemory

            //if (configuration.GetSection<bool>("UseInMemoryDatabase"))
            //{
            //    services.AddDbContextFactory<AppDataDbContext>(options => options.UseInMemoryDatabase("ApplicationDb"));
            //}
            //else
            //{
            //    //services.AddScoped<IUserAuthenticator, UserAuthenticator>();

            //    services.AddDbContext<AppDataDbContext>(
            //        options =>
            //        {
            //            options.EnableDetailedErrors(true);
            //            options.EnableSensitiveDataLogging(true);
            //            options.UseSqlServer(
            //                configuration.GetConnectionString("DefaultConnection"),
            //                x =>
            //                {
            //                    x.MigrationsAssembly(typeof(AppDataDbContext).Assembly.FullName);
            //                });
            //        }, ServiceLifetime.Transient
            //    );

            //    services.AddDbContextFactory<AppDataDbContext>(
            //        options =>
            //        {
            //            options.EnableDetailedErrors(true);
            //            options.EnableSensitiveDataLogging(true);
            //            options.UseSqlServer(
            //                configuration.GetConnectionString("DefaultConnection"),
            //                x =>
            //                {
            //                    x.MigrationsAssembly(typeof(AppDataDbContext).Assembly.FullName);
            //                });
            //        }, ServiceLifetime.Transient
            //    );
            //}

            services.AddRepositories();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IBillRepository, BillRepository>();
        }
        }
}
