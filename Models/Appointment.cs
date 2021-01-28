using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_Nagy_Cristina.Models
{
    public class Appointment
    {
        public int ID { get; set; }
        public int ChildrenID { get; set; }
        public Children Children { get; set; }
        public int AvailableTimeDateID { get; set; }
        public AvailableTimeDate AvailableTimeDate { get; set; }
    }
}
