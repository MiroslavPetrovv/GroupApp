using GroupApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GroupApp.Data.Configure
{
    using static GroupApp.Common.EntityValidationConstants.Course;
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.CreatorId)
                .IsRequired();



            builder.Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(TitleMaxLength);

            builder.Property(c=>c.Description)
                .IsRequired()
                .HasMaxLength(DescriptionMaxLength);

            builder.Property(c => c.CreatorId)
                .IsRequired();

            builder.Property(c=> c.CreatorId)
                .IsRequired();

            builder.HasOne(c => c.Group)
                .WithMany(g => g.Courses)
                .HasForeignKey(c => c.GroupId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.Lessons)
                .WithOne(m => m.Course)
                .HasForeignKey(m => m.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c=>c.Enrollments)
                .WithOne(e=>e.Course)
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
