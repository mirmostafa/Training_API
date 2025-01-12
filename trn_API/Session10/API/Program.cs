
using Application.Extensions;

using Scalar.AspNetCore;


namespace API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add logging
        builder.Services.AddLogging();

        builder.Services.AddControllers();
        builder.Services.AddOpenApi();


        // Create configuration using appsettings.json file
        //var configuration = builder.Configuration.AddJsonFile("appsettings.json").Build();

        // Add application services
        builder.Services.AddApplicationServices();
        
        //Add support to logging with SERILOG
        //builder.Host.UseSerilog((context, configuration) =>
        //    configuration.ReadFrom.Configuration(context.Configuration));

        var app = builder.Build();

        app.MapScalarApiReference(opt =>
        {
            opt.Title = "SRM API";
            opt.Theme = ScalarTheme.Mars;
            opt.DefaultHttpClient = new(ScalarTarget.Http, ScalarClient.Http11);
            opt.AddMetadata("version", "1.0");
        });

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
