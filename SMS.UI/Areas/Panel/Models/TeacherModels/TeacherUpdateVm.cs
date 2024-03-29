﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.UI.Areas.Panel.Models
{
    public class TeacherUpdateVm
    {
        public string TeacherId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string TcNo { get; set; }
        public string Password { get; set; }
        public List<string> TeacherLessons { get; set; }
        public string RedirectUrl { get; set; }
    }
}