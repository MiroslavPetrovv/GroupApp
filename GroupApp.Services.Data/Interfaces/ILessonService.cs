using GroupApp.Data.Models;
using GroupApp.ViewModels.Lesson;

namespace GroupApp.Services.Data.Interfaces
{
    public interface ILessonService
    {
        Task<Guid> Add(AddLessonInputModel model, string userId);
        Task Delete(Guid lessonId);
        Task Edit(EditLessonInputModel model);
        Task<Lesson> GetLessonByIdAsync(Guid lessonId);
    }
}
