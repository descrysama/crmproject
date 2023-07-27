using BluePillCRM.Business.Repository;
using BluePillCRM.Datas;
using BluePillCRM.Business.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BluePillCRM.Business.Services.Utilities;

namespace BluePillCRM.Application.Ioc
{
    public static class IoCApplication
    {

        public static IServiceCollection ConfigureInjectionDependencyRepository(this IServiceCollection services)
        {
            
            services.AddScoped<CrmConfigRepository>();
            services.AddScoped<AddressRepository>();
            services.AddScoped<UserRepository>();
            services.AddScoped<AccountRepository>();
            services.AddScoped<ProductRepository>();

            return services;
        }


        public static IServiceCollection ConfigureInjectionDependencyService(this IServiceCollection services)
        {
            services.AddScoped<CrmConfigService>();
            services.AddScoped<AddressService>();
            services.AddScoped<UserService>();
            services.AddScoped<UserUtilities>();
            services.AddScoped<AccountService>();
            services.AddScoped<ProductService>();

            return services;
        }

        public static IServiceCollection ConfigureDBContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("BddConnection");

            services.AddDbContext<BluePillCRMDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors());

            return services;
        }

    }
}
