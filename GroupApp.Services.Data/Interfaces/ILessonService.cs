using GroupApp.ViewModels.Lesson;

namespace GroupApp.Services.Data.Interfaces
{
    public interface ILessonService
    {
        Task AddLesson(AddLessonInputModel model, string userId , Guid courseId);
    }
}
