using System.ComponentModel.DataAnnotations;

namespace GroupApp.ViewModels.Lesson
{
    using static GroupApp.Common.EntityValidationConstants.Lesson;
    using static GroupApp.Common.EntityValidationMessages.Lesson;
    public class AddLessonInputModel
    {
        
    

        public AddLessonInputModel()
        {
            this.CreatedAt = DateTime.UtcNow.ToString(ReleaseDateFormat);
        }

        [Required(ErrorMessage = TitleRequiredMessage)]
        [MaxLength(TitleMaxLength)]
        [MinLength(TitleMinLentgh)]
        public string Title { get; set; }

        [Required(ErrorMessage = DescriptionRequiredMessage)]
        [MaxLength(ContentMaxLength)]
        [MinLength(ContentMinLenth)]
        public string Content { get; set; }

        [Required(ErrorMessage = ReleaseDateFormatRequiredMessage)]
        public string CreatedAt { get; set; }

        [Url]
        public string VideoURL { get; set; }

        public Guid CourseId { get; set; }

        
    }
}

