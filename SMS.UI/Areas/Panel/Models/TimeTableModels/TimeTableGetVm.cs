using SMS.Models.Entities;
using SMS.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.UI.Areas.Panel.Models
{
    public class TimeTableGetVm
    {
        public TimeTable[,] TimeTable { get; set; }
        public List<Group >Groups { get; set; }
        public List<Day> Days { get; set; }
        public List<LessonTeacher> LessonTeachers { get; set; }
        public List<Lesson> Lessons { get; set; }
        public List<Period> Periods { get; set; }
        public int? selectedGroupId { get; set; }
    }
}