using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupApp.ViewModels.Course
{
    using static GroupApp.Common.EntityValidationConstants.Course;
    using static GroupApp.Common.EntityValidationMessages.Course;
    public class EditCourseInputModel
    {
        
        public Guid Id { get; set; }

        [Required(ErrorMessage = TitleRequiredMessage)]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = DescriptionRequiredMessage)]
        [MaxLength(DescriptionMaxLength)]
        [MinLength(DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "Please select an image")]
        public string OldBanner { get; set; } = null!;

        public IFormFile? Banner { get; set; } 

        public Guid GroupId { get; set; }

        
    }
}
