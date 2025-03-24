using GroupApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GroupApp.Data.Configure
{
    using static GroupApp.Common.EntityValidationConstants.TextChannel;
    public class TextChannelConfiguration : IEntityTypeConfiguration<TextChannel>
    {
        public void Configure(EntityTypeBuilder<TextChannel> builder)
        {
            builder
                .HasKey(t => t.Id);

            builder
                .Property(tc => tc.Name)
                .IsRequired()
                .HasMaxLength(NameMaxLength);

            builder
                .Property(tc => tc.Description)
                .IsRequired()
                .HasMaxLength(DescriptionMaxLength);

            builder
                .HasOne(tc => tc.Group)
                .WithMany(g => g.TextChannels) 
                .HasForeignKey(tc => tc.GroupId) 
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(tc => new { tc.GroupId, tc.Name })
            .IsUnique();

        }
    }
}
