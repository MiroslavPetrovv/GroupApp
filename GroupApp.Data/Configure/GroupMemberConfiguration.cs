using GroupApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GroupApp.Data.Configure
{
    using static GroupApp.Common.EntityValidationConstants.GroupMember;
    public class GroupMemberConfiguration : IEntityTypeConfiguration<GroupMember>
    {
        
        public void Configure(EntityTypeBuilder<GroupMember> builder)
        {
            builder
                .HasKey(gm => gm.Id); // Primary key

            builder
                .Property(gm => gm.UserId)
                .IsRequired();

            builder
                .Property(gm => gm.GroupId)
                .IsRequired();

            builder
                .HasOne(gm => gm.Group)
                .WithMany(g => g.GroupMembers)
                .HasForeignKey(gm => gm.GroupId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(gm => gm.User)
                .WithMany(u => u.GroupMemberships)
                .HasForeignKey(gm => gm.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Property(gm => gm.NickName)
                .IsRequired()
                .HasMaxLength(nickNameMaxLength);

        }
    }
}
