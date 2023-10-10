using CleanArchitectureExample.Application.Core.Abstractions.Authentication;
using CleanArchitectureExample.Application.Core.Abstractions.Common;
using CleanArchitectureExample.Application.Core.Abstractions.Data;
using CleanArchitectureExample.Domain.Services;
using CleanArchitectureExample.Infrastructure.Authentication.Settings;
using CleanArchitectureExample.Infrastructure.Authentication;
using CleanArchitectureExample.Infrastructure.Persistence;
using CleanArchitectureExample.Infrastructure.Persistence.Context;
using CleanArchitectureExample.Infrastructure.Persistence.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using CleanArchitectureExample.Infrastructure.Cryptography;
using CleanArchitectureExample.Application.Core.Abstractions.Cryptography;
using CleanArchitectureExample.Infrastructure.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace CleanArchitectureExample.Infrastructure
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Registers the necessary services with the DI framework.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns>The same service collection.</returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(configuration["Jwt:SecurityKey"]))
                });

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SettingsKey));

            services.AddScoped<IUserIdentifierProvider, UserIdentifierProvider>();

            services.AddScoped<IJwtProvider, JwtProvider>();

            string connectionString = configuration.GetConnectionString(ConnectionString.SettingsKey);

            services.AddSingleton(new ConnectionString(connectionString));

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<ApplicationDbContext>());

            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddTransient<IDateTime, MachineDateTime>();

            services.AddTransient<IPasswordHasher, PasswordHasher>();

            services.AddTransient<IPasswordHashChecker, PasswordHasher>();

            return services;
        }
    }
}
