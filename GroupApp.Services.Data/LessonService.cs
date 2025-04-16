using GroupApp.Data;
using GroupApp.Data.Models;
using GroupApp.Services.Data.Interfaces;
using GroupApp.ViewModels.Lesson;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Net.Http.Headers;

namespace GroupApp.Services.Data
{
    public class LessonService : BaseService, ILessonService
    {
        private readonly ApplicationDbContext _context;
        public LessonService(ApplicationDbContext _context)
        {
            this._context = _context;
        }

        public async Task<Guid> Add(AddLessonInputModel model, string userId)
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
                Duration = model.Duration,
                LessonOrder = model.LessonOrder,

            };

            _context.Add(lesson);
            _context.SaveChanges();

            return lesson.Id;
        }

        public async Task Delete(Guid lessonId)
        {
            var lessonToDelete = await _context.Lessons.FirstOrDefaultAsync(x => x.Id == lessonId);
            if (lessonToDelete is null)
            {
                return;
            }
            _context.Lessons.Remove(lessonToDelete);
            await _context.SaveChangesAsync();

        }

        public async Task Edit(EditLessonInputModel model)
        {
            var lesson = await _context.Lessons.FirstOrDefaultAsync(x=>x.Id==model.Id);
            lesson.Duration = model.Duration;
            lesson.LessonOrder = model.LessonOrder;
            lesson.Title = model.Title;
            lesson.Content = model.Content;
            lesson.VideoURL = model.VideoURL;
            _context.Lessons.Update(lesson);
            await _context.SaveChangesAsync();
        }

        public async Task<Lesson> GetLessonByIdAsync(Guid lessonId)
        {
            var lesson = await _context.Lessons.FirstAsync(x=>x.Id == lessonId);
            return lesson;
        }
    }
}
