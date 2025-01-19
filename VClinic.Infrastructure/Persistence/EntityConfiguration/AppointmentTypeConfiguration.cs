using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VClinic.Domain.Entities;

namespace VClinic.Infrastructure.Persistence.EntityConfiguration
{
    public class AppointmentTypeConfiguration : IEntityTypeConfiguration<AppointmentType>
    {
        public void Configure(EntityTypeBuilder<AppointmentType> builder)
        {
            builder.HasKey(at => at.AppointmentTypeId);

            builder.Property(at => at.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(at => at.Description)
                .HasMaxLength(500);

            builder.Property(at => at.DefaultDuration)
                .IsRequired();

            builder.ToTable("AppointmentTypes");
        }
    }
}
