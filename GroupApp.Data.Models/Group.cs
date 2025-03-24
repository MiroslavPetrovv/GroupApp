
using GroupApp.Data.Models;


namespace GroupApp.Data.Models
{
    public class Group
    {

        public Group()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        
        public string Title{ get; set; }

        
        public string Description{ get; set; }

       
        public DateTime CreatedAt { get;private set; } = DateTime.UtcNow;

        
        public string OwnerId { get; set; }

        
        public ApplicationUser Owner{ get; set; }

        public ICollection<GroupMember> GroupMembers { get; set; } 
            = new HashSet<GroupMember>();

        public ICollection<TextChannel> TextChannels { get; set; } 
            = new HashSet<TextChannel>();
    }
}
