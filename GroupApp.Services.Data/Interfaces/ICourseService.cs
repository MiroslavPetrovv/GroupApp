﻿using GroupApp.Data.Models;
using GroupApp.ViewModels.Course;
using GroupApp.ViewModels.Group;

namespace GroupApp.Services.Data.Interfaces
{
    public interface ICourseService 
    {
        Task AddCourseAsync(AddCourseInputModel model, string userId, string image);

        Task AddPersonInCourseAsync(string userId,Guid courseId);

        Task<CourseLessonsDisplayViewModel> DisplayCourseAsync(Guid courseId);

        Task<Course> GetCourseByIdAsync(Guid courseId);


        Task Edit(EditCourseInputModel model, string image);

        Task<Guid> GetFirstLessonIdAsync(Guid courseId);

        
    }
}
