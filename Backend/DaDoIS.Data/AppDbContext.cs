using DaDoIS.Data.Configurations;
using DaDoIS.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DaDoIS.Data;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public required DbSet<Client> Clients { get; init; }
    public required DbSet<City> Cities { get; init; }
    public required DbSet<Citizenship> Citizenship { get; init; }

    public required DbSet<Currency> Currencies { get; init; }
    public required DbSet<Deposit> Deposits { get; init; }
    public required DbSet<DepositContract> DepositContracts { get; init; }
    public required DbSet<Credit> Credits { get; init; }
    public required DbSet<CreditContract> CreditContracts { get; init; }

    public required DbSet<BankAccount> BankAccounts { get; init; }
    public required DbSet<TransitLog> TransitLogs { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClientConfiguration).Assembly);
    }
}
