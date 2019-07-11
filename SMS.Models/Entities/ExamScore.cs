using SMS.Models.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.Models.Entities
{
    public class ExamScore
    {
        [Key, ForeignKey("Student"), Column(Order = 10)]
        public string StudentId { get; set; }
        public virtual AppUser Student { get; set; }

        [Key, ForeignKey("Exam"), Column(Order = 3000)]
        public int ExamId { get; set; }
        public virtual Exam Exam { get; set; }

        [Required]
        public decimal Score { get; set; }
    }
}
