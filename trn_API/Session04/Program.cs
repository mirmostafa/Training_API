using Microsoft.Extensions.DependencyInjection;

using Session04;
using Session04.Application.Interfaces;
using Session04.Application.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        // 1. Create a ServiceCollection
        var services = new ServiceCollection();

        // 2. Register services
        ConfigureServices(services);

        // 3. Build the ServiceProvider
        var serviceProvider = services.BuildServiceProvider();

        // 4. Resolve the required service
        var app = serviceProvider.GetService<App>();
        
        app.Run();
    }

    private static void ConfigureServices(ServiceCollection services)
    {
        // Register application entry point
        services.AddTransient<App>();

        // Register other services
        services.AddTransient<IGreetingService, GreetingService>();
    }
}