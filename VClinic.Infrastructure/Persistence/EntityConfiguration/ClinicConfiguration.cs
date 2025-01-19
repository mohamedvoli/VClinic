using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VClinic.Domain.Entities;

namespace VClinic.Infrastructure.Persistence.EntityConfiguration
{
    public class ClinicConfiguration : IEntityTypeConfiguration<Clinic>
    {
        public void Configure(EntityTypeBuilder<Clinic> builder)
        {
            builder.HasKey(c => c.ClinicId);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(c => c.Branches)
                .WithOne(b => b.Clinic)
                .HasForeignKey(b => b.ClinicId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Clinics");
        }
    }
}
