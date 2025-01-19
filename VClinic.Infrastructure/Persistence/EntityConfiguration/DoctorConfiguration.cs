using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VClinic.Domain.Entities;

namespace VClinic.Infrastructure.Persistence.EntityConfiguration
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(d => d.DoctorId);

            builder.Property(d => d.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(d => d.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(d => d.Specialization)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(d => d.Phone)
                .HasMaxLength(20);

            builder.Property(d => d.Email)
                .HasMaxLength(100);

            builder.HasMany(d => d.DoctorBranchAssignment)
                .WithOne(dba => dba.Doctor)
                .HasForeignKey(dba => dba.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Doctors");
        }
    }
}
