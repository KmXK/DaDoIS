using DaDoIS.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DaDoIS.Data.Configurations;

public class CardConfiguration : IEntityTypeConfiguration<Card>
{
    public void Configure(EntityTypeBuilder<Card> builder)
    {
        builder
            .HasOne(x => x.Client)
            .WithMany(t => t.Cards)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(x => x.BankAccount)
            .WithMany(t => t.Cards)
            .OnDelete(DeleteBehavior.NoAction);
    }
}