using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Orojas.Api.Services.Tokens
{
    /// <summary>
    /// ValidacionJwtServices, validador y configuracion del servicio de authentication
    /// </summary>
    /// <author>Oscar Julian Rojas Garces</author>
    /// <date>26/09/2020</date>
    public static class ValidacionJwtServices
    {
        /// <summary>
        /// Configuracion del servicios authentication
        /// </summary>
        /// <param name="services">Services netcore</param>
        /// <param name="config">Configuracion aplicaciones</param>
        /// <returns>Collection de configuracion de servicios aplicacion</returns>
        public static IServiceCollection ValidacionJwtServicesExtensions(
           this IServiceCollection services, IConfiguration config)
        {
            string key = config["JwtOptions:ClaveSecreta"];

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken =true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                };

                options.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                   {
                       context.Response.Headers.Add("Token-Valido", "true");
                       return Task.CompletedTask;
                   },
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("Token-Expiro", "true");
                        }
                        return Task.CompletedTask;
                    }
                };
            });

            return services;
        }
    }
}