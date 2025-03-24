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
    using static GroupApp.Common.EntityValidationConstants.Lesson;
    public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.HasKey(l => l.Id);

            builder.Property(l => l.Content)
                .IsRequired()
                .HasMaxLength(ContentMaxLength);

            builder.HasOne(l=>l.Module)
                .WithMany(m=>m.Lessons)
                .HasForeignKey(l=>l.ModuleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(l => l.ModuleId)
                .IsRequired();
        }
    }
}
