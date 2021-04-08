using IdentityServer.Web.ApiServices;
using IdentityServer.Web.ApiServices.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServer.Web.Configurations
{
    public static class ConfigureWebServices
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProductsWebService, ProductsWebService>();
            return services;
        }
    }
}
