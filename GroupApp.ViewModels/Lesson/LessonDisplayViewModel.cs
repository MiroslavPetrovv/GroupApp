using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupApp.ViewModels.Lesson
{
    
    public class LessonDisplayViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

       public string Content { get; set; }

        public Guid CourseId { get; set; }

        public int LessonsOrder {  get; set; }

        public string Duration { get; set; }

        public string VideoURL { get; set; }
    }
}
