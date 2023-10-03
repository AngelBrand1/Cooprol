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
    }
}
