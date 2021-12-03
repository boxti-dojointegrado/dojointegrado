using BoxTI.DojoIntegrado.Domain.Interfaces;
using BoxTI.DojoIntegrado.Infrastructure.Data;
using BoxTI.DojoIntegrado.Infrastructure.Data.Repositories;
using BoxTI.DojoIntegrado.Services.PasswordHasher;
using BoxTI.DojoIntegrado.Services.TokenService;
using Microsoft.EntityFrameworkCore;

namespace BoxTI.DojoIntegrado.API.Configurations
{
    public static class AuthConfiguration
    {
        public static IServiceCollection AddAuthConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("dojointegradodb");

            services.AddDbContext<ApplicationDbContext>(
                options => options
                    .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPasswordHasher, BCryptPasswordHasher>();
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}
