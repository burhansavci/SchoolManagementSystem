using SMS.Models.Entities;
using System.Collections.Generic;

namespace SMS.UI.Areas.Panel.Models
{
    public class TeacherGetVm
    {public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string TcNo { get; set; }
        public List<Lesson> TeacherLessons { get; set; }       
        public List<Lesson> LessonList { get; set; }
        public bool IsActive { get; set; }
    }
}