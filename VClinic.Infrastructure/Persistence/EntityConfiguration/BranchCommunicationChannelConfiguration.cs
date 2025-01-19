using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VClinic.Domain.Entities;

namespace VClinic.Infrastructure.Persistence.EntityConfiguration
{
    public class BranchCommunicationChannelConfiguration : IEntityTypeConfiguration<BranchCommunicationChannel>
    {
        public void Configure(EntityTypeBuilder<BranchCommunicationChannel> builder)
        {
            builder.HasKey(bcc => new { bcc.BranchId, bcc.CommunicationChannelId });

            builder.HasOne(bcc => bcc.Branch)
                .WithMany(b => b.BranchCommunicationChannels)
                .HasForeignKey(bcc => bcc.BranchId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(bcc => bcc.CommunicationChannel)
                .WithMany()
                .HasForeignKey(bcc => bcc.CommunicationChannelId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("BranchCommunicationChannels");
        }
    }
}
