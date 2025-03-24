using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupApp.Data.Models
{
    public class Course
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string CreatorId { get; set; } //ApplicationUser

        public ApplicationUser Creator { get; set; }

        public DateTime CreatedAt { get;private set; } = DateTime.UtcNow;

        public ICollection<Module> Modules { get; set; } 
            = new List<Module>();
        public ICollection<Enrollment> Enrollments{ get; set; } 
            = new List<Enrollment>();

        
    }
}
