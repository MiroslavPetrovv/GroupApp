
using GroupApp.Data.Models.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GroupApp.Data.Models
{
    public class Group
    {
        public Group()
        {
            GroupMembers = new List<GroupMember>();
            TextChannels = new List<TextChannel>();
        }
        
        public Guid Id { get; set; }

        
        public string Title{ get; set; }

        
        public string Description{ get; set; }

       
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        
        public string OwnerId { get; set; }

        
        public ApplicationUser Owner{ get; set; }

        public List<GroupMember> GroupMembers { get; set; } 
        public List<TextChannel> TextChannels { get; set; }
    }
}
