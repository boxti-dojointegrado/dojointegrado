using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BoxTI.DojoIntegrado.API.Configurations
{
    public static class JwtConfiguration
    {
        public static void AddJwtConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var key = Encoding.ASCII.GetBytes(configuration.GetValue<string>("AuthSettings:AccessTokenSecret"));

            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions => {
                bearerOptions.RequireHttpsMetadata = true;
                bearerOptions.SaveToken = true;
                bearerOptions.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });
        }

        public static void UseAuthConfig(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
