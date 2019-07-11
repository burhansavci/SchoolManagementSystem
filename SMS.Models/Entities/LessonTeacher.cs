using SMS.Models.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.Models.Entities
{
    public class LessonTeacher
    {
        [Key, ForeignKey("Lesson"), Column(Order = 10)]
        public int LessonId { get; set; }
        public virtual Lesson Lesson { get; set; }

        [Key, ForeignKey("Teacher"), Column(Order = 3000)]
        public string TeacherId { get; set; }
        public virtual AppUser Teacher { get; set; }
    }
}
