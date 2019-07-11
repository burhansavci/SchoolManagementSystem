using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.UI.Areas.Panel.Models
{
    public class GroupUpdateVm
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public string RedirectUrl { get; set; }
    }
}