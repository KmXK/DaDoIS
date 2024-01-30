using DaDoIS.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DaDoIS.Data.Configurations;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder
            .HasOne(x => x.LivingCity)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);
        
        builder
            .HasOne(x => x.RegistrationCity)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);
        
        builder
            .HasOne(x => x.Citizenship)
            .WithMany()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
