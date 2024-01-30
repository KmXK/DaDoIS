using DaDoIS.Data.Configurations;
using DaDoIS.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DaDoIS.Data;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Client> Clients { get; init; } = null!;

    public DbSet<City> Cities { get; init; } = null!;

    public DbSet<Citizenship> Citizenship { get; init; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClientConfiguration).Assembly);
    }
}
