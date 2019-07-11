using SMS.Models.Entities;
using SMS.Models.Identity;
using System.Collections.Generic;

namespace SMS.UI.Areas.Panel.Models
{
    public class ExamsGetVm
    {
        public Exam  Exam { get; set; }
        //public List<Lesson> Lessons { get; set; }
        //public List <Group> Groups { get; set; }
        //public List<Day> Days { get; set; }
        //public List<Schedule> Schedules { get; set; }
        public string DayName { get; set; }
        public string ScheduleName { get; set; }
        public string ExamStartTime { get; set; }
        public int? selectedGroupId { get; set; }
    }
}