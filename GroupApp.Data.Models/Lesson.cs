using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupApp.Data.Models
{
    public class Lesson
    {
        
        public Guid Id { get; set; }

        public Guid CourseId { get; set; }

        public Course Course { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedAt { get;  set; } 

        public int LessonOrder { get; set; }

        public double Duration { get; set; }

        public string VideoURL { get; set; }

        
    }
}
