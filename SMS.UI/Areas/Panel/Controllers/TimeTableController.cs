using Microsoft.AspNet.Identity;
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
    public class TimeTableController : Controller
    {
        DataService service = new DataService();
        public ActionResult GetTimeTables(int? selectedGroupId = 1)
        {
            if (HttpContext.User.IsInRole("student"))
            {
                var userManager = service.UnitOfWork.Members.Users;
                var currentStudentId = userManager.FindByName(HttpContext.User.Identity.Name).Id;
                selectedGroupId = service.UnitOfWork.StudentGroups.Get(x => x.StudentId == currentStudentId).SingleOrDefault().GroupId;
            };
            var groupManager = service.UnitOfWork.Groups;
            var lessonTeacherManager = service.UnitOfWork.LessonTeacher;
            var periodManager = service.UnitOfWork.Periods;
            var dayManager = service.UnitOfWork.Days;
            var scheduleManager = service.UnitOfWork.Schedules;
            var timeTableManager = service.UnitOfWork.TimeTables;

            var scheduleList = scheduleManager.Get();
            var dayList = dayManager.Get();
            var periodList = periodManager.Get();
            var groupList = groupManager.Get();
            var lessonTeacher = lessonTeacherManager.Get();
            var lessons = service.UnitOfWork.Lessons.Get();
            var timeTableList = timeTableManager.Get(x => x.GroupId == selectedGroupId && x.Lesson.IsActive == true).OrderBy(x => x.DayId).ThenBy(x => x.ScheduleId).ToList();
            TimeTable[,] timeTable = new TimeTable[5, 7];
            var k = 0;
            for (int i = 0; i < timeTable.GetLength(0); i++)
            {
                for (int j = 0; j < timeTable.GetLength(1); j++)
                {
                    if (timeTableList.ElementAtOrDefault(k) == null)
                    {
                        timeTable[i, j] = null;
                        continue;
                    }
                    if ((timeTableList[k].ScheduleId - 1) == j && (timeTableList[k].DayId - 1) == i)
                    {
                        timeTable[i, j] = timeTableList[k];
                        k++;
                    }
                    else
                    {
                        timeTable[i, j] = null;
                    }

                }
            }
            var model = new TimeTableGetVm
            {
                TimeTable = timeTable,
                Days = dayList,
                Groups = groupList,
                LessonTeachers = lessonTeacher,
                Lessons = lessons,
                Periods = periodList,
                selectedGroupId = selectedGroupId
            };
            return View(model);
        }
        [Authorize(Roles = "principal,personnel")]
        public ActionResult Post(TimeTableAddVm data)
        {
            var timeTableManager = service.UnitOfWork.TimeTables;
            timeTableManager.Insert(new TimeTable
            {
                LessonId = data.LessonId,
                TeacherId = data.TeacherId,
                GroupId = data.GroupId,
                PeriodId = data.PeriodId,
                DayId = data.DayId,
                ScheduleId = data.ScheduleId

            });
            service.UnitOfWork.Save();
            return RedirectToAction("GetTimeTables", new { data.selectedGroupId });
        }
        [Authorize(Roles = "principal,personnel")]
        public ActionResult Update(TimeTableUpdateVm data)
        {
            var timeTableManager = service.UnitOfWork.TimeTables;
            var toBeUpdatedTimeTable = timeTableManager.Get(x => x.DayId == data.DayId && x.ScheduleId == data.ScheduleId && x.GroupId == data.GroupId && x.Lesson.IsActive == true).FirstOrDefault();
            timeTableManager.Delete(x => x.DayId == toBeUpdatedTimeTable.DayId && x.ScheduleId == toBeUpdatedTimeTable.ScheduleId && x.GroupId == toBeUpdatedTimeTable.GroupId && x.Lesson.IsActive == true);
            service.UnitOfWork.Save();
            toBeUpdatedTimeTable.TeacherId = data.TeacherId;
            toBeUpdatedTimeTable.LessonId = data.LessonId;
            timeTableManager.Insert(new TimeTable
            {
                PeriodId = toBeUpdatedTimeTable.PeriodId,
                DayId = toBeUpdatedTimeTable.DayId,
                ScheduleId = toBeUpdatedTimeTable.ScheduleId,
                TeacherId = toBeUpdatedTimeTable.TeacherId,
                LessonId = toBeUpdatedTimeTable.LessonId,
                GroupId = toBeUpdatedTimeTable.GroupId,
            });
            service.UnitOfWork.Save();
            return RedirectToAction("GetTimeTables", new { data.selectedGroupId });
        }
        [Authorize(Roles = "principal,personnel")]
        public ActionResult Delete(TimeTableDeleteVm data)
        {
            var timeTableManager = service.UnitOfWork.TimeTables;
            var toBeDeletedTimeTable = timeTableManager.Get(x => x.DayId == data.DayId && x.ScheduleId == data.ScheduleId && x.GroupId == data.GroupId && x.Lesson.IsActive == true).FirstOrDefault();
            timeTableManager.Delete(x => x.DayId == toBeDeletedTimeTable.DayId && x.ScheduleId == toBeDeletedTimeTable.ScheduleId && x.GroupId == toBeDeletedTimeTable.GroupId && x.Lesson.IsActive == true);
            service.UnitOfWork.Save();
            return RedirectToAction("GetTimeTables", new { data.selectedGroupId });
        }
    }
}