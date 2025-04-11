using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GroupApp.Common.EntityValidationConstants;

namespace GroupApp.Data.Models
{
    public class Course
    {
        
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string CreatorId { get; set; } //ApplicationUser

        public ApplicationUser Creator { get; set; }

        public Guid GroupId { get; set; }

        public Group Group { get; set; }

        public DateTime CreatedAt { get; set; }

        public string? Banner { get; set; }

        public ICollection<Lesson> Lessons { get; set; } 
            = new HashSet<Lesson>();
        public ICollection<Enrollment> Enrollments{ get; set; } 
            = new HashSet<Enrollment>();

        
    }
}
