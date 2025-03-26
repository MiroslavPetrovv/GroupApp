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
            public const string ReleaseDateFormat = "MM/yyyy";
            public const string ReleaseDateRequiredMessage = "Release date is required in format MM/yyyy";
        }
    }
}
