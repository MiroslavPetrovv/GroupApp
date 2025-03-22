using GroupApp.Data.Models;
using GroupApp.Data.Models.Enums;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GroupApp.Data.Models
{
    public class GroupMember
    {
        public Guid Id { get; set; }

        public string NickName { get; set; }

        public string GroupId { get; set; }
        public Group Group { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; } 

        public GroupRole Role { get; set; }

        public DateTime JoinedAt { get;private set; } = DateTime.UtcNow;
    }
}