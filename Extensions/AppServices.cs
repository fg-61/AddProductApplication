using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductApplication.Repository;

namespace ProductApplication.Extensions
{
    public static class AppServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
            IConfiguration configuration)
        {

            services.AddScoped<ProductRepo>();
            services.AddScoped<SparePartRepo>();
            services.AddScoped<ProductSparePartRepo>();
            //loose coupling


            return services;
        }
    }
}