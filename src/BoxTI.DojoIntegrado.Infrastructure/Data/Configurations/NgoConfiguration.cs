using BoxTI.DojoIntegrado.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BoxTI.DojoIntegrado.Infrastructure.Data.Configurations;

public class NgoConfiguration : IEntityTypeConfiguration<Ngo>
{
    public void Configure(EntityTypeBuilder<Ngo> builder)
    {
        builder.HasKey(p => p.OrganizationId);
    }
}