using Microsoft.AspNet.Identity;
using SMS.BLL.Service;
using SMS.Models.Entities;
using SMS.Models.Identity;
using SMS.UI.Areas.Panel.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SMS.UI.Areas.Panel.Controllers
{
    [Authorize(Roles = "principal,personnel")]
    public class TeacherController : Controller
    {
        DataService service = new DataService();
        public ActionResult GetTeachers()
        {
            var lessonTeachers = service.UnitOfWork.LessonTeacher
                .Get()
                .Where(x => x.Teacher.IsActive == true)
                .OrderBy(x => x.TeacherId)
                .ToList();
            var lessons = service.UnitOfWork.Lessons.Get();
            var models = new List<TeacherGetVm>();
            foreach (var lessonTeacher in lessonTeachers)
            {
                var k = models.FindLast(x => x.Id == lessonTeacher.TeacherId);
                if (k != null)
                {
                    k.TeacherLessons.Add(lessonTeacher.Lesson);
                    continue;
                }
                var model = new TeacherGetVm
                {
                    Id = lessonTeacher.TeacherId,
                    UserName = lessonTeacher.Teacher.UserName,
                    FirstName = lessonTeacher.Teacher.FirstName,
                    LastName = lessonTeacher.Teacher.LastName,
                    PhoneNumber = lessonTeacher.Teacher.PhoneNumber,
                    Email = lessonTeacher.Teacher.Email,
                    TcNo = lessonTeacher.Teacher.TCNo,
                    IsActive = lessonTeacher.Teacher.IsActive,
                    TeacherLessons = new List<Lesson>(),
                    LessonList = lessons
                };
                model.TeacherLessons.Add(lessonTeacher.Lesson);
                models.Add(model);

            }
            return View(models);
        }
        [HttpPost]
        public ActionResult Post(TeacherAddVm data)
        {
            if (ModelState.IsValid)
            {
                var userManager = service.UnitOfWork.Members.Users;
                var lessonTeacherManager = service.UnitOfWork.LessonTeacher;
                var lessonManager = service.UnitOfWork.Lessons;
                userManager.Create(new AppUser
                {
                    UserName = data.UserName,
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    PhoneNumber = data.PhoneNumber,
                    Email = data.Email,
                    TCNo = data.TcNo,
                    IsActive = true,
                }, data.Password);
                var userId = userManager.FindByName(data.UserName).Id;
                userManager.AddToRole(userId, "teacher");
                foreach (var lessonName in data.TeacherLessons)
                {
                    var lessonId = lessonManager.Get(x => x.Name == lessonName).FirstOrDefault().Id;
                        /*lessonTeacherManager.Get(x => x.Lesson.Name == lessonName).FirstOrDefault().Lesson.Id;*/
                    lessonTeacherManager.Insert(new LessonTeacher
                    {
                        LessonId=lessonId,
                        TeacherId=userId,
                    });
                    service.UnitOfWork.Save();
                }        
            }
            return Redirect(data.RedirectUrl);
        }
        [HttpPost]
        public ActionResult Update(TeacherUpdateVm data)
        {
            if (ModelState.IsValid)
            {   //initilazing managers
                var userManager = service.UnitOfWork.Members.Users;
                var lessonManager = service.UnitOfWork.Lessons;
                var lessonTeacherManager = service.UnitOfWork.LessonTeacher;
                // get current user data
                var toBeUpdatedUser = userManager.FindById(data.TeacherId);
                var toBeUpdateLessonTeachers = lessonTeacherManager.Get(x => x.TeacherId == toBeUpdatedUser.Id);

                var toBeDeletedLessons = new List<Lesson>();
                foreach (var lesson in data.TeacherLessons)
                {
                    foreach (var toBeUpdateLessonTeacher in toBeUpdateLessonTeachers)
                    {
                        if (toBeUpdateLessonTeacher.Lesson.Name!=lesson)
                        {
                            toBeDeletedLessons.Add(toBeUpdateLessonTeacher.Lesson);
                        }
                    }                
                }                          
                //set coming data value to currentuser data
                toBeUpdatedUser.UserName = data.UserName;
                toBeUpdatedUser.FirstName = data.FirstName;
                toBeUpdatedUser.LastName = data.LastName;
                toBeUpdatedUser.PhoneNumber = data.PhoneNumber;
                toBeUpdatedUser.Email = data.Email;
                toBeUpdatedUser.TCNo = data.TcNo;
                //delete existing relation from join table
                foreach (var toBeDeletedLesson in toBeDeletedLessons)
                {
                    foreach (var toBeUpdateLessonTeacher in toBeUpdateLessonTeachers)
                    {
                        lessonTeacherManager.Delete(x => x.TeacherId == toBeUpdateLessonTeacher.TeacherId && x.LessonId == toBeDeletedLesson.Id);
                    }                   
                }
                service.UnitOfWork.Save();
                //insert new relation into join table
                userManager.Update(toBeUpdatedUser);
                foreach (var lessonName in data.TeacherLessons)
                {
                    var lessonId = lessonManager.Get(x => x.Name == lessonName).FirstOrDefault().Id;
                    lessonTeacherManager.Insert(new LessonTeacher
                    {
                        TeacherId = toBeUpdatedUser.Id,
                        LessonId = lessonId
                    });

                }
                
                service.UnitOfWork.Save();
            }
            return Redirect(data.RedirectUrl);
        }

        public void Delete(string userId)
        {
            var userManager = service.UnitOfWork.Members.Users;
            var teacher = userManager.FindById(userId);
            if (teacher != null)
            {
                teacher.IsActive = false;
                service.UnitOfWork.Save();
            }

        }
    }
}