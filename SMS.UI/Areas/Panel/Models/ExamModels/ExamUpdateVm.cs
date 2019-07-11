using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.UI.Areas.Panel.Models
{
    public class ExamUpdateVm
    {
        public int LessonId { get; set; }
        public int selectedGroupId { get; set; }
        public int ExamNumber { get; set; }
        public string ExamDate { get; set; }
        public int ScheduleId { get; set; }
    }
}