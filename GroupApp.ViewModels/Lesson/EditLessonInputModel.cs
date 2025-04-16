using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupApp.ViewModels.Lesson
{
    using static GroupApp.Common.EntityValidationConstants.Lesson;
    using static GroupApp.Common.EntityValidationMessages.Lesson;
    public class EditLessonInputModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = TitleRequiredMessage)]
        [MaxLength(TitleMaxLength)]
        [MinLength(TitleMinLentgh)]
        public string Title { get; set; }

        [Required(ErrorMessage = DescriptionRequiredMessage)]
        [MaxLength(ContentMaxLength)]
        [MinLength(ContentMinLenth)]
        public string Content { get; set; }

        [Url]
        public string VideoURL { get; set; }

        [Required]
        public int LessonOrder { get; set; }

        [Required]
        public double Duration { get; set; }

        public Guid CourseId { get; set; }
    }
}
