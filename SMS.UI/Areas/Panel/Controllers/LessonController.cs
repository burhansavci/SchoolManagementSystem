using SMS.BLL.Service;
using SMS.Models.Entities;
using SMS.UI.Areas.Panel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.UI.Areas.Panel.Controllers
{
    [Authorize(Roles = "principal,personnel")]
    public class LessonController : Controller
    {
        DataService service = new DataService();
        public ActionResult GetLessons()
        {
            var lessons = service.UnitOfWork.Lessons.Get(x => x.IsActive == true);
            var models = new List<LessonGetVm>();
            foreach (var lesson in lessons)
            {
                var model = new LessonGetVm
                {
                    Id = lesson.Id,
                    Name = lesson.Name,
                    IsActive = true,
                    AddedDate = lesson.AddedDate
                };
                models.Add(model);
            }
            return View(models);
        }
        [HttpPost]
        public ActionResult Post(LessonAddVm data)
        {
            if (ModelState.IsValid)
            {
                var lessonManager = service.UnitOfWork.Lessons;
                lessonManager.Insert(new Lesson
                {
                    Name = data.Name,
                    AddedDate = DateTime.Now,
                    IsActive = true,
                });

                service.UnitOfWork.Save();
            }
            return Redirect(data.RedirectUrl);
        }
        public ActionResult Update(LessonUpdateVm data)
        {
            if (ModelState.IsValid)
            {
                var lessonManager = service.UnitOfWork.Lessons;
                var toBeUpdatedLesson = lessonManager.GetById(data.LessonId);
                toBeUpdatedLesson.Name = data.Name;
                lessonManager.Update(toBeUpdatedLesson);
                service.UnitOfWork.Save();
            }
            return Redirect(data.RedirectUrl);
        }
        public void Delete(int lessonId)
        {
            var lessonManager = service.UnitOfWork.Lessons;
            var lesson = lessonManager.GetById(lessonId);
            if (lesson != null)
            {
                lesson.IsActive = false;
                service.UnitOfWork.Save();
            }
        }
    }
}