using Application;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplication();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();
app.UseExceptionMiddleware();
using var scope = app.Services.GetService<IServiceScopeFactory>()?.CreateScope();
scope?.ServiceProvider.GetRequiredService<ApplicationDbContext>().Database.Migrate();
app.Run();
