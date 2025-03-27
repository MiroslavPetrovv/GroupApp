using GroupApp.Data.Models;

namespace GroupApp.Data.Models
{
    public class Message
    {
        
        public Guid Id { get; set; }

        public Guid TextChannelId { get; set; }

        public TextChannel TextChannel { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public DateTime CreatedAt { get; set; } 

        public string Content { get; set; }
    }
}