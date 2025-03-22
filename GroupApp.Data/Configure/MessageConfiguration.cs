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
    using static GroupApp.Common.EntityValidationConstants.Message;
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(m => m.ApplicationUser)
                .WithMany(u=>u.Messages) 
                .HasForeignKey(m => m.ApplicationUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(m => m.TextChannel)
                .WithMany(tc => tc.Messages) 
                .HasForeignKey(m => m.TextChannelId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(m => m.Content)
                .IsRequired()
                .HasMaxLength(ContentMaxLength);
        }
    }
}
