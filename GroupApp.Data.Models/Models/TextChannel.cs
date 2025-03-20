namespace GroupApp.Data.Models
{
    public class TextChannel
    {
        public TextChannel()
        {
            Messages = new List<Message>();
           
        }
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string  Description { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }

        public List<Message> Messages { get; set; }

        
    }
}