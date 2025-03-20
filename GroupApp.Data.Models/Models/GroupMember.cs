using Microsoft.AspNet.Identity.EntityFramework;

namespace GroupApp.Data.Models
{
    public class GroupMember
    {
        public Guid Id { get; set; }

        public string NickName { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }

        public string UserId { get; set; }
        public IdentityUser User { get; set; } 

        public DateTime JoinedAt { get; set; } = DateTime.UtcNow;
    }
}