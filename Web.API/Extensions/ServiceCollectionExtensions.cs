using Microsoft.OpenApi.Models;
namespace Web.API.Extensions
{
    /// <summary>
    /// Contains extensions methods for the service collection class.
    /// </summary>
    internal static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Configures the Swagger services.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <returns>The same service collection.</returns>
        internal static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(swaggerGenOptions =>
                swaggerGenOptions.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Product API",
                    Version = "v1"
                }));

            return services;
        }
    }
}
