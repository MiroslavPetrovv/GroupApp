using GroupApp.Services.Data.Interfaces;
using GroupApp.ViewModels.Course;
using GroupApp.Web.Infra.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
            
            
            return RedirectToAction("DisplayClassRoom", "Group", new{groupId = model.GroupId });
            //change it later

        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Join(Guid courseId)
        {
            //Add logic for authorization in the future
            string userId = User.GetId();
            await courseService.AddPersonInCourseAsync(userId, courseId);
            return RedirectToAction("Display", new { courseId = courseId });

        }

        [HttpGet]
        public async Task<IActionResult> Display(Guid courseId)
        {

            return View();
        }
    }
}
