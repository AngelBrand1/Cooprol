using System.Net;
using System.Reflection.PortableExecutable;
using System.Buffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cooprol.Data;
using Cooprol.Business.IServices;
using Cooprol.Business.Services;
using Cooprol.API.Controllers;
using Cooprol.Data.IRepository;
using Cooprol.Data.Repository;
using Microsoft.AspNetCore.Identity;
using Cooprol.Data.Models;
using Cooprol.API.Services;
using System.Security.Cryptography.X509Certificates;
using Cooprol.API.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
namespace Cooprol.API.Extensions;

public static class AplicationServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services) => services.AddCors(
        options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            );
        }
    );
    public static void AddAplicationsServices(this IServiceCollection services)
    {

        // Registra tus repositorios y unidades de trabajo
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Registra tus servicios
        services.AddScoped<IBillService, BillService>();
        services.AddScoped<IProducerService, ProducerService>();
        services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
        services.AddScoped<IUserService, UserService>();

    }

    public static void AddJwt(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JWT>(configuration.GetSection("JWT"));
        services.AddAuthentication(options => 
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(o => 
        {
            o.RequireHttpsMetadata = false;
            o.SaveToken = false;
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ClockSkew =  TimeSpan.Zero,
                ValidIssuer = configuration["JWT:Issuer"],
                ValidAudience = configuration["JWT:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]))
            };
        });
    }
}
