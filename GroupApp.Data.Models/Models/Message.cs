using GroupApp.Data.Models.Models;

namespace GroupApp.Data.Models
{
    public class Message
    {
        public Guid Id { get; set; }

        public int TextChannelId { get; set; }

        public TextChannel TextChannel { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public DateTime CreatedAt { get;private set; } = DateTime.UtcNow;

        public string Content { get; set; }
    }
}