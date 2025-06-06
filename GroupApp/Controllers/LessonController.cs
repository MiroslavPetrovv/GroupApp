﻿using GroupApp.Services.Data.Interfaces;
using GroupApp.ViewModels.Lesson;
using GroupApp.Web.Infra.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GroupApp.Controllers
{
    [Authorize]
    public class LessonController : BaseController
    {
        private readonly ILessonService lessonService;
        private readonly ICourseService courseService;

        public LessonController(ILessonService lessonService,ICourseService courseService)
        {
            this.courseService = courseService;
            this.lessonService = lessonService;
        }

        [HttpGet]
        
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
            var currentLessonId = await lessonService.Add(model, userId);
            return RedirectToAction("Details" , "Course" , new {courseId = model.CourseId , currentLessonId = currentLessonId });
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

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid lessonId)
        {
            var lesson = await lessonService.GetLessonByIdAsync(lessonId);
            
            if (lesson is null)
            {

            }
            var courseId = lesson.CourseId;
            await lessonService.Delete(lessonId);
            var course = await courseService.GetCourseByIdAsync(courseId);
            if (course.Lessons.Count ==0)
            {
                return RedirectToAction("DisplayClassRoom", "Group" ,new { groupId = course.GroupId });
            }
            var firstCourseLessonId = await courseService.GetFirstLessonIdAsync(courseId);
            return RedirectToAction("Details", "Course", new { courseId = lesson.CourseId, currentLessonId = firstCourseLessonId });
            
        }

    }
}
