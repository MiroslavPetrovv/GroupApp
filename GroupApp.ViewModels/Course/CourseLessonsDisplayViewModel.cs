using GroupApp.ViewModels.Lesson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupApp.ViewModels.Course
{
    public class CourseLessonsDisplayViewModel
    {
        public Guid Id { get; set; }

        public string OwnerId { get; set; }
        public List<LessonDisplayViewModel> Lessons { get; set; } =
            new List<LessonDisplayViewModel>();
    }
}
