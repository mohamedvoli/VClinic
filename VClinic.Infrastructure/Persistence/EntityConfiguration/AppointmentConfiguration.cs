using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VClinic.Domain.Entities;

namespace VClinic.Infrastructure.Persistence.EntityConfiguration
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasKey(b => b.BranchId);

            //builder.Property(b => b.Name)
            //       .IsRequired()
            //       .HasMaxLength(100);

            //builder.HasOne(b => b.Clinic)
            //       .WithMany(c => c.Branches)
            //       .HasForeignKey(b => b.ClinicId);

            builder.ToTable("Branches");
        }
    }
}
