using DaDoIS.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DaDoIS.Data.Configurations;

public class DepositContractConfiguration : IEntityTypeConfiguration<DepositContract>
{
    public void Configure(EntityTypeBuilder<DepositContract> builder)
    {
        builder
            .HasOne(x => x.Client)
            .WithMany(t => t.DepositContracts)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(x => x.Deposit)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);
    }
}