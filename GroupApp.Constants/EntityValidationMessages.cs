using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupApp.Common
{
    public static class EntityValidationMessages
    {
        
        public static class Group
        {
            public const string TitleRequiredMessage = "Group title is required";
            public const string DescriptionRequiredMessage = "Group description is required";
            public const string ReleaseDateRequiredMessage = "Release date is required in format MM-dd-yy";
            public const string ReleaseDateFormat = "MM-dd-yy";
        }

        public static class Course
        {
            public const string TitleRequiredMessage = "Course title is required";
            public const string DescriptionRequiredMessage = "Course description is required";
            public const string ReleaseDateFormat = "MM-dd-yy";
            public const string ReleaseDateFormatRequiredMessage = "Release date is required in format MM-dd-yy";
        }
        public static class Lesson
        {
            public const string TitleRequiredMessage = "Lesson title is required";
            public const string DescriptionRequiredMessage = "Lesson title is required";
            public const string ReleaseDateFormat = "MM-dd-yy";
            public const string ReleaseDateFormatRequiredMessage = "Release date is required in format MM-dd-yy";
        }
    }
}
