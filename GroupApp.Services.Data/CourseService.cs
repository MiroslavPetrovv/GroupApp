using GroupApp.Data;
using GroupApp.Data.Models;
using GroupApp.Services.Data.Interfaces;
using GroupApp.ViewModels.Course;
using GroupApp.ViewModels.Group;
using GroupApp.ViewModels.Lesson;
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

            await _context.Courses.AddAsync(course);
            //group.Courses.Add(course);
            await _context.SaveChangesAsync();
        }
        public async Task Edit(EditCourseInputModel model, string image)
        {
            var course = await _context.Courses.FindAsync(model.Id);

            course.Title = model.Title;
            course.Description = model.Description;
            course.Banner = image;

            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
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
            await _context.SaveChangesAsync();
        }

        public async Task<CourseLessonsDisplayViewModel> DisplayCourseAsync(Guid courseId)
        {
            var course = await _context.Courses
                .AsNoTracking()
                .Where(c => c.Id == courseId)
                .Include(c => c.Lessons)
                .Select(c => new CourseLessonsDisplayViewModel
                {
                    Id = c.Id,
                    OwnerId = c.CreatorId,
                    Lessons = c.Lessons.Select(l => new LessonDisplayViewModel
                    {
                        Id = l.Id,
                        Content = l.Content,
                        CourseId = l.CourseId,
                        Title = l.Title,
                        VideoURL = l.VideoURL,
                        
                    }).ToList()
                }).FirstOrDefaultAsync();

            return course;
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
