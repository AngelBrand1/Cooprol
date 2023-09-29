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
// builder.Services.ConfigureCors();
// builder.Services.AddAplicationsServices();
builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
