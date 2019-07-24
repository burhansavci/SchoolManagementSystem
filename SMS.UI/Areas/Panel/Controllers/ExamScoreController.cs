using SMS.BLL;
using SMS.BLL.Service;
using SMS.UI.Areas.Panel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.UI.Areas.Panel.Controllers
{
    public class ExamScoreController : Controller
    {
        DataService service = new DataService();
        Converter Converter = new Converter();

        public ActionResult GetExamScores()
        {
            var examManager = service.UnitOfWork.Exams;
            var scheduleManager = service.UnitOfWork.Schedules;

            var examList = examManager.Get(x => x.IsActive == false);
            var scheduleList = scheduleManager.Get(x => x.IsActive == true);

            ViewBag.Schedules = scheduleList;
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
    }
}