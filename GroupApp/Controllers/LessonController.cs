using GroupApp.Services.Data.Interfaces;
using GroupApp.ViewModels.Lesson;
using GroupApp.Web.Infra.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GroupApp.Controllers
{
    public class LessonController : BaseController
    {
        private readonly ILessonService lessonService;

        public LessonController(ILessonService lessonService)
        {
            this.lessonService = lessonService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Create(Guid courseId)
        {
            var lessonModel = new AddLessonInputModel
            {
                CourseId = courseId,
            };

            return View(lessonModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddLessonInputModel model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }
            string userId = User.GetId();
            await lessonService.AddLesson(model, userId);
            return Ok();
        }

    }
}
