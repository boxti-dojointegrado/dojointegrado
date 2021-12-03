using BoxTI.DojoIntegrado.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BoxTI.DojoIntegrado.Infrastructure.Data.Configurations;

public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
{
    public void Configure(EntityTypeBuilder<Organization> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.AddressId).IsRequired();
        builder.Property(e => e.Phone).IsRequired();
        builder.Property(e => e.CorporateName).IsRequired();
        builder.Property(e => e.FantasyName).IsRequired();
        builder.Property(e => e.Cnpj).IsRequired();
        builder.Property(e => e.Description).IsRequired();
    }
}
