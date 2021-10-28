using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace CleanArchMVC.Infra.IoC
{
    public static class DependecyInjectionJWT
    {
        public static IServiceCollection AddInfraestructureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            // Informar o tipo de Autenticação JWT e definição do Modelo de Desafio de Autenticação
            services.AddAuthentication(option => {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            // Habilita a Autenticação Jwt usando o desafio definido e valida Token
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["JWT:Issuer"],
                        ValidAudience = configuration["JWT:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"])),
                        ClockSkew = TimeSpan.Zero
                };
            });

            return services;
        }
    }
}
