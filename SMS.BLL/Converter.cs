using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.BLL
{
    public class Converter
    {
        public string DayConverter(DayOfWeek day)
        {
            if (day==DayOfWeek.Monday)
            {
                return "Pazartesi";
            }
            else if(day==DayOfWeek.Tuesday)
            {
                return "Salı";
            }
            else if (day==DayOfWeek.Wednesday)
            {
                return "Çarşamba";
            }
            else if (day==DayOfWeek.Thursday)
            {
                return "Perşembe";
            }
            else if (day==DayOfWeek.Friday)
            {
                return "Cuma";
            }
            return "Çevirme işlemi gerçekleşmedi"; 
        }
    }
}
