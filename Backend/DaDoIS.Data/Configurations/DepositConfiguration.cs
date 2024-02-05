using DaDoIS.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DaDoIS.Data.Configurations;

public class DepositConfiguration : IEntityTypeConfiguration<Deposit>
{
    public void Configure(EntityTypeBuilder<Deposit> builder)
    {
        builder
            .HasOne(x => x.Currency)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);
    }
}