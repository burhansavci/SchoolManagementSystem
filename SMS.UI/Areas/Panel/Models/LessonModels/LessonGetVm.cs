﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.UI.Areas.Panel.Models
{
    public class LessonGetVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime AddedDate { get; set; }
    }
}