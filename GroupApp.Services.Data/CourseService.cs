using GroupApp.Data;
using GroupApp.Data.Models;
using GroupApp.Services.Data.Interfaces;
using GroupApp.ViewModels.Course;
using GroupApp.ViewModels.Group;
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

        
    }
}
