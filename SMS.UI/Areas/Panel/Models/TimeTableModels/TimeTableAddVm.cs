using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.UI.Areas.Panel.Models
{
    public class TimeTableAddVm
    {
        public int LessonId { get; set; }
        public string TeacherId { get; set; }
        public int GroupId { get; set; }
        public int PeriodId { get; set; }
        public int DayId { get; set; }
        public int ScheduleId { get; set; }
        public int? selectedGroupId { get; set; }
    }
}