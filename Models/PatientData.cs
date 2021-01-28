using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_Nagy_Cristina.Models
{
    public class ChildrenData
    {
        public IEnumerable<Children> Childrens { get; set; }
        public IEnumerable<AvailableTimeDate> AvailableTimeDates { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }

    }
}
