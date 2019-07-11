using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.UI.Areas.Panel.Models
{
    public class StudentGetVm
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ParentPhoneNumber { get; set; }
        public string Email { get; set; }
        public string TcNo { get; set; }
        public string Group { get; set; }
        public bool IsActive { get; set; }
        public int GroupId { get; set; }
    }
}