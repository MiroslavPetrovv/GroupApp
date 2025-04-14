using GroupApp.Data;
using GroupApp.Data.Models;
using GroupApp.Services.Data.Interfaces;
using GroupApp.ViewModels.Course;
using GroupApp.ViewModels.Group;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace GroupApp.Services.Data
{
    public class CourseService : BaseService, ICourseService
    {
        private readonly ApplicationDbContext _context;

        public CourseService(ApplicationDbContext _context)
        {
            this._context = _context;
        }
        public async Task AddCourseAsync(AddCourseInputModel model, string userId, string image)
        {
            string format = "MM-dd-yy";
            DateTime createdAt = DateTime.ParseExact(model.CreatedAt.ToString(), format, CultureInfo.InvariantCulture,
                DateTimeStyles.None);
            var group = await _context.Groups.FindAsync(model.GroupId);
            if (group.OwnerId != userId)
            {
                return;
            }
            Course course = new Course
            {
                GroupId = model.GroupId,
                CreatorId = userId,
                CreatedAt = createdAt,
                Banner = image,
                Description = model.Description,
                Title = model.Title,
            };

            _context.Courses.Add(course);
            //group.Courses.Add(course);
            _context.SaveChanges();    
        }
        public async Task Edit(EditCourseInputModel model, string image)
        {
            var course = await _context.Courses.FindAsync(model.Id);

            course.Title = model.Title;
            course.Description = model.Description;
            course.Banner = image;

            _context.Courses.Update(course);
            _context.SaveChanges();
        }
        public async Task AddPersonInCourseAsync(string userId, Guid courseId)
        {
            var course = await _context.Courses.FindAsync(courseId);
            var isPersoninCourse = course.Enrollments
                .FirstOrDefault(e => e.UserId == userId);
            if (isPersoninCourse == null)
            {
                return;
                //Person is already in course soo skip
            }
            var enrollment = new Enrollment
            {
                CourseId = courseId,
                EnrolledAt = DateTime.UtcNow,
                UserId = userId,
            };

            course.Enrollments.Add(enrollment);
            _context.SaveChanges();
        }

        public Task<CourseLessonsDisplayViewModel> DisplayGroupAsync(Guid courseId)
        {
            throw new NotImplementedException();
        }

        public async Task<Course> GetCourseByIdAsync(Guid courseId)
        {
            var course = await _context.Courses.FindAsync(courseId);
            if (course == null)
            {
                return null;
            }

            return course;        
        }

       
    }
}
