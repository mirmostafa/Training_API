#nullable disable

using Microsoft.EntityFrameworkCore;

using Session07.Models;

namespace Session07.DbContexts;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
}