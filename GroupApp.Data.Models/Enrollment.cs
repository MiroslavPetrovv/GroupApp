using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupApp.Data.Models
{
    public class Enrollment
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public Guid CourseId { get; set; }

        public Course Course { get; set; }

        public DateTime EnrolledAt { get; private set; } = DateTime.UtcNow;
    }
}
