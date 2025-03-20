
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GroupApp.Data.Data.Models
{
    using static GroupApp.Common.EntityValidationConstants.Group;
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

        
        public IdentityUser Owner{ get; set; }

        public List<GroupMember> GroupMembers { get; set; } 
        public List<TextChannel> TextChannels { get; set; }
    }
}
