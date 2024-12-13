
using Microsoft.EntityFrameworkCore;

using Session07.DbContexts;
using Session07.Services;

using System;

namespace Session07;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<ApplicationDbContext>(options => 
            options.UseInMemoryDatabase("TestDatabase"));
        builder.Services.AddScoped<IProductService, ProductService>();

        builder.Services.AddControllers();
        
        var app = builder.Build();

        app.MapControllers();

        app.Run();
    }
}
