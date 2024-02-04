using DaDoIS.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DaDoIS.Data.Configurations;

public class TransitionLogConfiguration : IEntityTypeConfiguration<TransitLog>
{
    public void Configure(EntityTypeBuilder<TransitLog> builder)
    {
        builder
            .HasOne(x => x.Source)
            .WithMany()
            .OnDelete(DeleteBehavior.SetNull);

        builder
            .HasOne(x => x.Target)
            .WithMany()
            .OnDelete(DeleteBehavior.SetNull);
    }
}