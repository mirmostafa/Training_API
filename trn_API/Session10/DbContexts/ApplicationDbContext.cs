#nullable disable

using Microsoft.EntityFrameworkCore;

namespace Session10.DbContexts;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options)
    {
    }
}

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}