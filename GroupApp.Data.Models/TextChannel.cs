﻿namespace GroupApp.Data.Models
{
    public class TextChannel
    {
        

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string  Description { get; set; }

        public DateTime CreatedAt { get; set; }
        public Guid GroupId { get; set; }
        public Group Group { get; set; }

        


    }
}