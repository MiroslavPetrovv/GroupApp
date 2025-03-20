namespace GroupApp.Data.Data.Models
{
    public class TextChannel
    {
        public Guid Id { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}