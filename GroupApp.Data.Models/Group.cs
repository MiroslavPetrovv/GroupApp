namespace GroupApp.Data.Models
{
    using GroupApp.Data.Models.Enums;
    public class Group
    {

        public Group()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        
        public string Title{ get; set; }

        
        public string Description{ get; set; }

        public GroupCategory Category { get; set; }

        public DateTime CreatedAt { get; set; } 

        public string? Banner {get; set;}
        public string OwnerId { get; set; }

        
        public ApplicationUser Owner{ get; set; }

        public ICollection<GroupMember> GroupMembers { get; set; } 
            = new HashSet<GroupMember>();

        public ICollection<TextChannel> TextChannels { get; set; } 
            = new HashSet<TextChannel>();
    }
}
