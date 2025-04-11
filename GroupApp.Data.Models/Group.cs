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

        public HashSet<GroupMember> GroupMembers { get; set; } 
            = new HashSet<GroupMember>();

        public HashSet<TextChannel> TextChannels { get; set; } 
            = new HashSet<TextChannel>();

        public HashSet<Course> Courses { get; set; }
            = new HashSet<Course> { new Course() };
    }
}
