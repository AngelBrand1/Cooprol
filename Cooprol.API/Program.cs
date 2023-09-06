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
    opt => opt.UseInMemoryDatabase("Cooprol")
);

builder.Services.AddScoped<IProducerService, ProducerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
