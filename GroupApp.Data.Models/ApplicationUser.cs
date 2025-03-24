

namespace GroupApp.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    public class ApplicationUser : IdentityUser
    {
        
        public string DisplayName { get; set; }
        public ICollection<Group> OwnedGroups { get; set; } 
            = new HashSet<Group>();

        public ICollection<GroupMember> GroupMemberships { get; set; } 
            = new HashSet<GroupMember>();

        public ICollection<Enrollment> Enrollments { get; set; } 
            = new HashSet<Enrollment>();

        public ICollection<Message> Messages { get; set; } 
            = new HashSet<Message>();

    }
}
