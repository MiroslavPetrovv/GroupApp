using GroupApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .HasMaxLength(NameMaxLength); // Limit name leng

            builder
                .Property(tc => tc.Description)
                .IsRequired()
                .HasMaxLength(DescriptionMaxLength);

            builder
                .HasOne(tc => tc.Group)
                .WithMany(g => g.TextChannels) // Group's collection of TextChannels
                .HasForeignKey(tc => tc.GroupId) // Foreign Key in TextChannel
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(tc => new { tc.GroupId, tc.Name })
            .IsUnique();

        }
    }
}
