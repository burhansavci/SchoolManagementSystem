using Microsoft.AspNet.Identity;
using SMS.BLL;
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
    public class ExamController : Controller
    {
        DataService service = new DataService();
        public ActionResult GetExams(int? selectedGroupId = 1)
        {
            if (HttpContext.User.IsInRole("student"))
            {
                var userManager = service.UnitOfWork.Members.Users;
                var currentStudentId = userManager.FindByName(HttpContext.User.Identity.Name).Id;
                selectedGroupId = service.UnitOfWork.StudentGroups.Get(x => x.StudentId == currentStudentId).SingleOrDefault().GroupId;
            }
            var examManager = service.UnitOfWork.Exams;
            var timeTableManager = service.UnitOfWork.TimeTables;
            var groupManager = service.UnitOfWork.Groups;

            var lessonList = service.UnitOfWork.Lessons.Get(x => x.IsActive == true);
            var groupList = groupManager.Get(x => x.IsActive == true);
            var examList = examManager.Get(x => x.GroupId == selectedGroupId);
            var scheduleList = service.UnitOfWork.Schedules.Get(x => x.IsActive == true);
            Converter Converter = new Converter();
            ViewBag.Lessons = lessonList;
            ViewBag.Groups = groupList;
            ViewBag.Days = service.UnitOfWork.Days.Get();
            ViewBag.Schedules = scheduleList;
            ViewBag.selectedGroupId = selectedGroupId;
            ViewBag.TimeTables = timeTableManager.Get(x => x.GroupId == selectedGroupId);
            var models = new List<ExamsGetVm>();
            foreach (var exam in examList)
            {
                var examStartTime = $"{exam.ExamDate.ToString("HH:mm")}";
                var model = new ExamsGetVm
                {
                    Exam = exam,
                    ExamStartTime = examStartTime,
                    DayName = Converter.DayConverter(exam.ExamDate.DayOfWeek),
                    ScheduleName = scheduleList.Where(x => x.StartTime == examStartTime).FirstOrDefault().Name,
                };
                models.Add(model);
            }
            return View(models);
        }

        [HttpPost]
        [Authorize(Roles = "principal,personnel")]
        public ActionResult Post(ExamAddVm data)
        {
            var examManager = service.UnitOfWork.Exams;
            var timetableManager = service.UnitOfWork.TimeTables;
            var scheduleManager = service.UnitOfWork.Schedules;

            var teacherId = timetableManager.Get(x => x.LessonId == data.LessonId && x.GroupId == data.selectedGroupId).FirstOrDefault().TeacherId;
            var scheduleStartTime = scheduleManager.Get(x => x.Id == data.ScheduleId).SingleOrDefault().StartTime;
            var formattedExamDate = data.ExamDate.Replace("/", ".");
            string newExamDate;
            if (int.Parse(scheduleStartTime.Split(':')[0]) >= 12)
            {
                newExamDate = $"{formattedExamDate} {scheduleStartTime}:00 PM";
            }
            else
            {
                newExamDate = $"{formattedExamDate} {scheduleStartTime}:00 AM";
            }
            examManager.Insert(new Exam
            {
                AddedDate = DateTime.Now,
                TeacherId = teacherId,
                GroupId = data.selectedGroupId,
                LessonId = data.LessonId,
                ExamDate = DateTime.Parse(newExamDate, System.Globalization.CultureInfo.InvariantCulture),
                ExamNumber = data.ExamNumber
            });
            service.UnitOfWork.Save();
            return RedirectToAction("GetExams", new { selectedGroupId = data.selectedGroupId });
        }

        [Authorize(Roles = "principal,personnel")]
        public ActionResult Update(ExamUpdateVm data)
        {
            var examManager = service.UnitOfWork.Exams;
            var timetableManager = service.UnitOfWork.TimeTables;
            var scheduleManager = service.UnitOfWork.Schedules;

            var toBeUpdatedExam = examManager.Get(x => x.LessonId == data.LessonId && x.GroupId == data.selectedGroupId).SingleOrDefault();
            examManager.Delete(x => x.GroupId == toBeUpdatedExam.GroupId && x.LessonId == toBeUpdatedExam.LessonId);
            service.UnitOfWork.Save();
            var toBeUpdatedTeacherId = timetableManager.Get(x => x.GroupId == data.selectedGroupId && x.LessonId == data.LessonId).FirstOrDefault().TeacherId;
            var scheduleStartTime = scheduleManager.Get(x => x.Id == data.ScheduleId).SingleOrDefault().StartTime;
            var formattedExamDate = data.ExamDate.Replace("/", ".");
            string toBeUpdatedExamDate;
            if (int.Parse(scheduleStartTime.Split(':')[0]) >= 12)
            {
                toBeUpdatedExamDate = $"{formattedExamDate} {scheduleStartTime}:00 PM";
            }
            else
            {
                toBeUpdatedExamDate = $"{formattedExamDate} {scheduleStartTime}:00 AM";
            }
            examManager.Insert(new Exam
            {
                AddedDate = DateTime.Now,
                IsActive = toBeUpdatedExam.IsActive,
                TeacherId = toBeUpdatedTeacherId,
                GroupId = data.selectedGroupId,
                LessonId = data.LessonId,
                ExamDate = DateTime.Parse(toBeUpdatedExamDate, System.Globalization.CultureInfo.InvariantCulture),
                ExamNumber =data.ExamNumber,
            });
            service.UnitOfWork.Save();
            return RedirectToAction("GetExams", new { selectedGroupId = data.selectedGroupId });
        }

        [Authorize(Roles = "principal,personnel")]
        public void Delete(int examId)
        {
            var examManager = service.UnitOfWork.Exams;
            examManager.Delete(x=>x.Id==examId);
            service.UnitOfWork.Save();
        }
    }
}