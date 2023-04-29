using Microsoft.OpenApi.Models;
using LuzInga.Infra;
using LuzInga.Application;
using LuzInga.Domain;
using Microsoft.AspNetCore.Mvc;
using LuzInga.Domain.Entities;
using LuzInga.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "LuzIngaServer", Version = "v1" });
    c.EnableAnnotations();
});


builder.Configuration
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile(
        $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", 
        optional: true, 
        reloadOnChange: true
    );


builder
    .AddInfra()
    .AddDomain()
    .AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseResponseCachingEx();
app.UseLogging();
app.MapControllers();
app.Run();
