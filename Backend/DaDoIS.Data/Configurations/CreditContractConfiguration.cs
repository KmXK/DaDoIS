using DaDoIS.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DaDoIS.Data.Configurations;

public class CreditContractConfiguration : IEntityTypeConfiguration<CreditContract>
{
    public void Configure(EntityTypeBuilder<CreditContract> builder)
    {
        builder
            .HasOne(x => x.Client)
            .WithMany(t => t.CreditContracts)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(x => x.Credit)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);
    }
}