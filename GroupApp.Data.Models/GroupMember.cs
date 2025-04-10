using GroupApp.Data.Models.Enums;

namespace GroupApp.Data.Models
{
    public class GroupMember
    {
        
        public Guid Id { get; set; }

        

        public Guid GroupId { get; set; }
        public Group Group { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; } 

        public GroupRole Role { get; set; }

        public DateTime JoinedAt { get; set; } 
    }
}