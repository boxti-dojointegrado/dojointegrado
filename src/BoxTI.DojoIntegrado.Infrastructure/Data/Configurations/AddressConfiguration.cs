using BoxTI.DojoIntegrado.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoxTI.DojoIntegrado.Infrastructure.Data.Configurations;

public class AddressConfiguration: IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.StreetName).IsRequired();
        builder.Property(e => e.Neighborhood).IsRequired();
        builder.Property(e => e.City).IsRequired();
        builder.Property(e => e.ZipCode).IsRequired();
        builder.Property(e => e.State).IsRequired();
    }
}