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
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            string userId = User.GetId();
            await lessonService.Add(model, userId);
            return RedirectToAction("Details" , "Course" , new {courseId = model.CourseId });
        }

        [HttpGet]

        public async Task<IActionResult> Edit(Guid lessonId)
        {
            var lesson = await lessonService.GetLessonByIdAsync(lessonId);
            if (lesson == null)
            {
                return RedirectToAction("Details", "Course" , new { courseId = lesson.CourseId, currentLessonId = lesson.Id });
            }
            var lessonForEdit = new EditLessonInputModel
            {
                Id = lesson.Id,
                Content = lesson.Content,
                Duration = lesson.Duration,
                LessonOrder = lesson.LessonOrder,
                Title = lesson.Title,
                VideoURL = lesson.VideoURL,
                CourseId = lesson.CourseId,
            };

            return View(lessonForEdit);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(EditLessonInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await lessonService.Edit(model);
            return RedirectToAction("Details", "Course", new { courseId = model.CourseId, currentLessonId = model.Id });
        }

    }
}
