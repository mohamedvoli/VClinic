using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VClinic.Domain.Entities;

namespace VClinic.Infrastructure.Persistence.EntityConfiguration
{
    public class InsuranceProviderConfiguration : IEntityTypeConfiguration<InsuranceProvider>
    {
        public void Configure(EntityTypeBuilder<InsuranceProvider> builder)
        {
            builder.HasKey(i => i.InsuranceProviderId);

            builder.Property(i => i.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(i => i.ContactInformation)
                .HasMaxLength(200);

            builder.Property(i => i.CoverageDetails)
                .HasMaxLength(500);

            builder.ToTable("InsuranceProviders");
        }
    }
}
