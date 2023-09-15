using Microsoft.EntityFrameworkCore;
using Cooprol.Data;
using System;
using Cooprol.Business.IServices;
using Cooprol.Business.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CooprolContext>(
   
    opt => {
        string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }
);

// builder.Services.AddScoped<IProducerService, ProducerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using(var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    try
    {
        var context = services.GetRequiredService<CooprolContext>();
        await context.Database.MigrateAsync();
        await CooprolContextSeed.SeedAsync(context,loggerFactory);
    }
    catch (Exception ex)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex, "Ocurrio un mensaje en la migración");
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
