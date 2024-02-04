using DaDoIS.Data.Configurations;
using DaDoIS.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DaDoIS.Data;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Client> Clients { get; init; } = null!;
    public DbSet<City> Cities { get; init; } = null!;
    public DbSet<Citizenship> Citizenship { get; init; } = null!;

    public DbSet<Currency> Currencies { get; init; } = null!;
    public DbSet<Deposit> Deposits { get; init; } = null!;
    public DbSet<DepositContract> DepositContracts { get; init; } = null!;
    public DbSet<BankAccount> BankAccounts { get; init; } = null!;
    public DbSet<TransitLog> TransitLogs { get; init; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClientConfiguration).Assembly);
    }
}
