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
                .HasKey(gm => gm.Id);


            builder
                .HasOne(gm => gm.Group)
                .WithMany(g => g.GroupMembers)
                .HasForeignKey(g=>g.GroupId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(gm => gm.User)
                .WithMany(u => u.GroupMemberships)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Property(gm => gm.NickName)
                .IsRequired()
                .HasMaxLength(nickNameMaxLength);

        }
    }
}
