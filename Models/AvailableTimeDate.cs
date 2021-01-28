using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_Nagy_Cristina.Models
{
    public class AvailableTimeDate
    {
        public int ID { get; set; }
        public DateTime Availabilty { get; set; }
        public ICollection<Appointment> Appointments { get; set; }

    }
}
