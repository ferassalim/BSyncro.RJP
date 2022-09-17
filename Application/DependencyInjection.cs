using Application.Common.Middlewares;
using Domain.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddScoped<ExceptionMiddleware>();
            services.AddScoped(typeof(IRepository<>),typeof( ApplicationDbRepository<>));
            return services.AddValidatorsFromAssembly(assembly)
                .AddMediatR(assembly);
        }
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder app) =>
        app.UseMiddleware<ExceptionMiddleware>();

    }
}

