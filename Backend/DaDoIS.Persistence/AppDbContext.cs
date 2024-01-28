using DaDoIS.Models;
using Microsoft.EntityFrameworkCore;

namespace DaDoIS.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<Client> Clients { get; set; } = null!;

    public DbSet<City> Cities { get; set; } = null!;

    public DbSet<Citizenship> Citizenship { get; set; } = null!;
}
