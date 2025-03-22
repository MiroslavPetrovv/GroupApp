﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupApp.Data.Models.Models
{
    public class Module
    {
        public Guid Id { get; set; }

        public string CourseId { get; set; }

        public Course Course { get; set; }

        public int Duration { get; set; }

        public int ModuleOrder { get; set; }

        public DateTime CreatedAt { get;private set; } = DateTime.UtcNow;

        public ICollection<Lesson> Lessons { get; set; } =
            new List<Lesson>();
        
    }
}
