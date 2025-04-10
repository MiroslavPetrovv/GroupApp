using GroupApp.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GroupApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Group> Groups { get; set; } = null!;

        public DbSet<GroupMember> GroupMembers { get; set; } = null!;

        public DbSet<Course> Courses { get; set; } = null!;

        public DbSet<GroupApp.Data.Models.Module> Modules { get; set; } = null!;

        public DbSet<TextChannel> TextChannels { get; set; } = null!;

        

        public DbSet<Enrollment> Enrollments { get; set; } = null!;

        public DbSet<Lesson> Lessons { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
