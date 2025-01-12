using Application.DataSources;
using Application.Repositories;
using Application.Services;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services
            .AddDbContext<ApplicationDbContext>(o => o.UseInMemoryDatabase("kjdgkljdfglkdfhj"))
            .AddScoped<ProductRepository>()
            .AddScoped<ProductService>();
        return services;
    }
}
