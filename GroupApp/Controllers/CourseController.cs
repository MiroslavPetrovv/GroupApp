using GroupApp.Services.Data.Interfaces;
using GroupApp.ViewModels.Course;
using GroupApp.Web.Infra.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GroupApp.Controllers
{
    [Authorize]
    public class CourseController : BaseController
    {
        private readonly ICourseService courseService;

        public CourseController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        [HttpGet]
        

        public async Task<IActionResult> Create(Guid groupId)
        {
            var courseModel = new AddCourseInputModel()
            {
                GroupId = groupId,
            };


            return View(courseModel);
        }
        [HttpPost]
        
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
        
        //public async Task<IActionResult> Join(Guid courseId)
        //{
        //    //Add logic for authorization in the future
        //    string userId = User.GetId();
        //    await courseService.AddPersonInCourseAsync(userId, courseId);
        //    return RedirectToAction("Display", new { courseId = courseId });

        //}

        

        [HttpGet]
        
        public async Task<IActionResult> Edit(Guid courseId)
        {
            var course = await courseService.GetCourseByIdAsync(courseId);
            if (course == null)
            {
                return RedirectToAction("DisplayClassRoom", "Group", new { groupId = course.GroupId });
            }

            var courseForEdit = new EditCourseInputModel
            {
                Id = courseId,
                Title = course.Title,
                Description = course.Description,
                GroupId = course.GroupId,
                OldBanner = course.Banner

            };

            return View(courseForEdit);
        }

        [HttpPost]
        
        public async Task<IActionResult> Edit(EditCourseInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

           
            string imageBase64 = string.Empty;
            if(model.Banner != null && model.Banner.Length > 0)
            {
                
                using (var stream = model.Banner.OpenReadStream())
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        stream.CopyTo(memoryStream);
                        imageBase64 = Convert.ToBase64String(memoryStream.ToArray());

                    }
                }
                TempData["Message"] = "Image uploaded successfully";
                await courseService.Edit(model, imageBase64);
            }
            else
            {
                await courseService.Edit(model, model.OldBanner);
            }
            return RedirectToAction("DisplayClassRoom", "Group", new { groupId = model.GroupId });


        }

        [HttpGet]
        
        public async Task<IActionResult> Details(Guid courseId)
        {
            var courseLessons = await courseService.DisplayCourseAsync(courseId);

            return View(courseLessons);
        }

        [HttpGet]
        public async Task<IActionResult> Join(Guid courseId)
        {
            if (!ModelState.IsValid)
            {
                return View(courseId);
            }

            string userId = User.GetId();
            await courseService.AddPersonInCourseAsync(userId, courseId);
            return RedirectToAction(nameof(Details), new { courseId = courseId });
        }
    }
}
