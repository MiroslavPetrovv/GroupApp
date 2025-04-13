using GroupApp.Services.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GroupApp.ViewModels.Course;
using GroupApp.ViewModels.Group;
using GroupApp.Web.Infra.Extensions;

namespace GroupApp.Controllers
{
    public class CourseController : BaseController
    {
        private readonly ICourseService courseService;

        public CourseController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        [HttpGet]
        [Authorize]

        public async Task<IActionResult> Create(Guid groupId)
        {
            var courseModel = new AddCourseInputModel()
            {
                GroupId = groupId,
            };


            return View(courseModel);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(AddCourseInputModel model)
        {

            if (!ModelState.IsValid)
            {
                return this.View(model);
            }
            string imageBase64 = string.Empty;
            using (var stream = model.Banner.OpenReadStream())
            {
                using (var memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);
                    imageBase64 = Convert.ToBase64String(memoryStream.ToArray());

                }
            }
            TempData["Message"] = "Image uploaded successfully";
            string userId = User.GetId();
            await courseService.AddCourseAsync(model, userId, imageBase64);

            
            return View("DisplayClassroom", "Group");
            //change it later

        }
    }
}
