#nullable disable

using Microsoft.EntityFrameworkCore;

using Session07.Models;

namespace Session07.DbContexts;

public class ApplicationDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options)
    {
    }
}