using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupApp.ViewModels.Course
{
    public class CourseDisplayViewModel
    {
        public Guid Id { get; set; } 

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Banner { get; set; } = null!;

        public Guid GroupId { get; set; }

        public int Completeion { get; set; } 
    }
}
