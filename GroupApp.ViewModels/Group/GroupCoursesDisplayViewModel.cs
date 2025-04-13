using GroupApp.ViewModels.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupApp.ViewModels.Group
{
    public class GroupCoursesDisplayViewModel
    {
        public Guid Id { get; set; }
        public List<CourseDisplayViewModel> Courses { get; set; } = new List<CourseDisplayViewModel>();


    }
}
