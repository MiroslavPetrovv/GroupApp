

namespace GroupApp.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    public class ApplicationUser : IdentityUser
    {
        
        
        public HashSet<Group> OwnedGroups { get; set; } 
            = new HashSet<Group>();

        public HashSet<GroupMember> GroupMemberships { get; set; } 
            = new HashSet<GroupMember>();

        public HashSet<Enrollment> Enrollments { get; set; } 
            = new HashSet<Enrollment>();

        

    }
}
