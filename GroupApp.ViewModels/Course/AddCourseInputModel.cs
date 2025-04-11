using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace GroupApp.ViewModels.Course
{
    using static GroupApp.Common.EntityValidationConstants.Course;
    using static GroupApp.Common.EntityValidationMessages.Course;
    public class AddCourseInputModel
    {
        public AddCourseInputModel()
        {
            this.CreatedAt = DateTime.UtcNow.ToString(ReleaseDateFormat);
        }

        [Required(ErrorMessage = TitleRequiredMessage)]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = DescriptionRequiredMessage)]
        [MaxLength(DescriptionMaxLength)]
        [MinLength(DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "Please select an image")]
        public IFormFile Banner { get; set; } = null!;

        public Guid GroupId { get; set; }

        [Required(ErrorMessage = ReleaseDateFormatRequiredMessage)]
        public string CreatedAt { get; set; }
    }
}
