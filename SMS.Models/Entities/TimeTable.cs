using SMS.Models.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.Models.Entities
{
    public class TimeTable
    {
        [Key, ForeignKey("Group"), Column(Order = 1)]
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }

        [Key, ForeignKey("Teacher"), Column(Order = 1000)]
        public string TeacherId { get; set; }
        public virtual AppUser Teacher { get; set; }

        [Key, ForeignKey("Lesson"), Column(Order = 2000)]
        public int LessonId { get; set; }
        public virtual Lesson Lesson { get; set; }

        [Key, ForeignKey("Period"), Column(Order = 3000)]
        public int PeriodId { get; set; }
        public virtual Period Period { get; set; }

        [Key, ForeignKey("Day"), Column(Order = 4000)]
        public int DayId { get; set; }
        public virtual Day Day { get; set; }

        [Key, ForeignKey("Schedule"), Column(Order = 5000)]
        public int ScheduleId { get; set; }
        public virtual Schedule Schedule { get; set; }

    }
}
