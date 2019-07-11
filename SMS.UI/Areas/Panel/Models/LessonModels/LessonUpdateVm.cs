using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.UI.Areas.Panel.Models
{
    public class LessonUpdateVm
    {
        public int LessonId { get; set; }
        public string Name { get; set; }
        public string RedirectUrl { get; set; }
    }
}