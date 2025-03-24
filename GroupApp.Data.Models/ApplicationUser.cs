

namespace GroupApp.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    public class ApplicationUser : IdentityUser
    {
        
        public string DisplayName { get; set; }
        public ICollection<Group> OwnedGroups { get; set; } 
            = new List<Group>();

        public ICollection<GroupMember> GroupMemberships { get; set; } 
            = new List<GroupMember>();

        public ICollection<Enrollment> Enrollments { get; set; } 
            = new List<Enrollment>();

        public ICollection<Message> Messages { get; set; } 
            = new List<Message>();

    }
}
