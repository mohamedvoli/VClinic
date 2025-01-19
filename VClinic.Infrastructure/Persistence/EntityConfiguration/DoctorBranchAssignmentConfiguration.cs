using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VClinic.Domain.Entities;

namespace VClinic.Infrastructure.Persistence.EntityConfiguration
{
    public class DoctorBranchAssignmentConfiguration : IEntityTypeConfiguration<DoctorBranchAssignment>
    {
        public void Configure(EntityTypeBuilder<DoctorBranchAssignment> builder)
        {
            builder.HasKey(dba => dba.Id);

            builder.HasOne(dba => dba.Doctor)
                .WithMany(d => d.DoctorBranchAssignment)
                .HasForeignKey(dba => dba.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(dba => dba.Branch)
                .WithMany(b => b.DoctorBranchAssignment)
                .HasForeignKey(dba => dba.BranchId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("DoctorBranchAssignments");
        }
    }
}
