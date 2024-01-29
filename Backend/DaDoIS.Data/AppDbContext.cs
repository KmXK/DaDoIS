

using DaDoIS.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DaDoIS.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Client> Clients { get; set; } = null!;

    public DbSet<City> Cities { get; set; } = null!;

    public DbSet<Citizenship> Citizenship { get; set; } = null!;
}
