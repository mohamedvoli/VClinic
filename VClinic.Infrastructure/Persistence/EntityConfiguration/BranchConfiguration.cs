using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VClinic.Domain.Entities;

namespace VClinic.Infrastructure.Persistence.EntityConfiguration
{
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.HasKey(b => b.BranchId);

            builder.Property(b => b.Address)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasOne(b => b.Clinic)
                .WithMany()
                .HasForeignKey(b => b.ClinicId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.User)
                .WithMany()
                .HasForeignKey(b => b.ManagerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Branches");
        }
    }
}
