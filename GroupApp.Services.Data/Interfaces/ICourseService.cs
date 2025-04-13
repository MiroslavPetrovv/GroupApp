using GroupApp.Data.Models;
using GroupApp.ViewModels.Course;
using GroupApp.ViewModels.Group;

namespace GroupApp.Services.Data.Interfaces
{
    public interface ICourseService 
    {
        Task AddCourseAsync(AddCourseInputModel model, string userId, string image);

        
    }
}
