using Cooprol.API.Extensions;
using Cooprol.Data;
using Microsoft.EntityFrameworkCore;
using System;
using Cooprol.Business.IServices;
using Cooprol.Business.Services;
using Cooprol.Data.IRepository;
using Cooprol.Data.Repository;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureCors();
builder.Services.AddAplicationsServices();
builder.Services.AddControllers();
builder.Services.AddDbContext<CooprolContext>(options =>
{
    var serverVersion = ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), serverVersion);
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// using(var scope = app.Services.CreateScope())
// {
//     var services = scope.ServiceProvider;
//     var loggerFactory = services.GetRequiredService<ILoggerFactory>();
//     try
//     {
//         var context = services.GetRequiredService<CooprolContext>();
//         await context.Database.MigrateAsync();
//         // await CooprolContextSeed.SeedAsync(context,loggerFactory);
//     }
//     catch (Exception ex)
//     {
//         var logger = loggerFactory.CreateLogger<Program>();
//         logger.LogError(ex, "Ocurrio un mensaje en la migración");
//     }
// }
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
