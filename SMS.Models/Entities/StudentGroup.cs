using SMS.Models.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.Models.Entities
{
    public class StudentGroup
    {
        [Key, ForeignKey("Student"), Column(Order = 10)]
        public string StudentId { get; set; }
        public virtual AppUser Student { get; set; }

        [Key, ForeignKey("Group"), Column(Order = 3000)]
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
    }
}
