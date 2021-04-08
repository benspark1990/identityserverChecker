using IdentityServer.Api.Interfaces;
using IdentityServer.Api.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServer.Api.Configurations
{
    public static class ConfigureWebServices
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IAsyncRepository<>), typeof(AsyncRepository<>));

            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}
