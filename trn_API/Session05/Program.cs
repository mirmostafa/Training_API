using MediatR;

using Microsoft.AspNetCore.Hosting;

using Scalar.AspNetCore;

using Session05.Application.Commands;
using Session05.Application.Features.UserManagement.Handlers;
using Session05.Application.Features.UserManagement.Queries;
using Session05.Application.Interfaces;
using Session05.Application.Services;

internal static class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configure services
        builder.Services.AddApplicationServices();
        
        builder.Services
            .AddOpenApi()
            .AddControllers();

        var app = builder.Build();

        // Configure application
        app.MapControllers();

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.MapScalarApiReference();
        }

        app.Run();
    }

    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Registering in DI
        services.AddTransient<INotificationService, EmailService>();
        //services.AddTransient<INotificationService, SmsService>();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));


        return services;
    }
}