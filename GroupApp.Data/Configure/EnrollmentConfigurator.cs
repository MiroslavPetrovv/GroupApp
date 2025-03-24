using GroupApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GroupApp.Data.Configure
{
    public class EnrollmentConfigurator : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e=>e.User)
                .WithMany(u=>u.Enrollments)
                .HasForeignKey(e=>e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e=>e.Course)
                .WithMany(u=>u.Enrollments)
                .HasForeignKey(e=>e.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
