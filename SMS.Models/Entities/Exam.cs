using SMS.Models.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.Models.Entities
{
    public class Exam
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime AddedDate { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;

        public int ExamNumber { get; set; }

        [ForeignKey("Teacher")]
        public string TeacherId { get; set; }
        public virtual AppUser Teacher { get; set; }

        [ForeignKey("Group")]
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }

        [ForeignKey("Lesson")]
        public int LessonId { get; set; }
        public virtual Lesson Lesson { get; set; }

        [Required, Column(TypeName = "datetime2")]
        public DateTime ExamDate { get; set; }
    }
}
