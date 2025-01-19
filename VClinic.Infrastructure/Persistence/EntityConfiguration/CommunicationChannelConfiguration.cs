using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VClinic.Domain.Entities;

namespace VClinic.Infrastructure.Persistence.EntityConfiguration
{
    public class CommunicationChannelConfiguration : IEntityTypeConfiguration<CommunicationChannel>
    {
        public void Configure(EntityTypeBuilder<CommunicationChannel> builder)
        {
            builder.HasKey(cc => cc.CommunicationChannelId);

            builder.Property(cc => cc.Type)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(cc => cc.Value)
                .IsRequired()
                .HasMaxLength(100);

            builder.ToTable("CommunicationChannels");
        }
    }
}
