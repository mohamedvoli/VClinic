using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VClinic.Domain.Entities;

namespace VClinic.Infrastructure.Persistence.EntityConfiguration
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(p => p.PatientId);

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Address)
                .HasMaxLength(200);

            builder.Property(p => p.Phone)
                .HasMaxLength(20);

            builder.Property(p => p.Email)
                .HasMaxLength(100);

            builder.Property(p => p.MedicalConditions)
                .HasMaxLength(500);

            builder.Property(p => p.Allergies)
                .HasMaxLength(500);

            builder.Property(p => p.CurrentMedications)
                .HasMaxLength(500);

            builder.Property(p => p.OtherMedicalNotes)
                .HasMaxLength(1000);

            builder.Property(p => p.DateOfBirth)
                .IsRequired();

            builder.HasOne(p => p.InsuranceProvider)
                .WithMany()
                .HasForeignKey(p => p.InsuranceProviderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Patients");
        }
    }
}
