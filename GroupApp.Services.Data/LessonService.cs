using GroupApp.Data;
using GroupApp.Data.Models;
using GroupApp.Services.Data.Interfaces;
using GroupApp.ViewModels.Lesson;
using System.Globalization;

namespace GroupApp.Services.Data
{
    public class LessonService : BaseService, ILessonService
    {
        private readonly ApplicationDbContext _context;
        public LessonService(ApplicationDbContext _context)
        {
            this._context = _context;
        }

        public async Task AddLesson(AddLessonInputModel model, string userId)
        {
            string format = "MM-dd-yy";
            DateTime createdAt = DateTime.ParseExact(model.CreatedAt.ToString(), format, CultureInfo.InvariantCulture,
                DateTimeStyles.None);
            
            Lesson lesson = new Lesson
            {
                Title = model.Title,
                CreatedAt = createdAt,
                Content = model.Content,
                CourseId = model.CourseId,
                VideoURL = model.VideoURL,

            };

            _context.Add(lesson);
            _context.SaveChanges();
        }
    }
}
