namespace GroupApp.Data.Models
{
    public class TextChannel
    {
        

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string  Description { get; set; }

        public DateTime CreatedAt { get;private set; }
        public Guid GroupId { get; set; }
        public Group Group { get; set; }

        public ICollection<Message> Messages { get; set; } 
            = new HashSet<Message>();


    }
}