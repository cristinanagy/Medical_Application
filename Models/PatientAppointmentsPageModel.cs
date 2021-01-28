using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect_Nagy_Cristina.Data;

namespace Proiect_Nagy_Cristina.Models
{
    public class ChildrenAppointmentsPageModel : PageModel
    {
        public List<AssignedAvailabilityData> AssignedAvailabilityDataList;
        public void PopulateAssignedAvailabilityData(Proiect_Nagy_CristinaContextV2 context, Children children)
        {
            var allDates = context.AvailableTimeDate;
            var appointments = new HashSet<int>(children.Appointments.Select(c => c.ChildrenID));
            AssignedAvailabilityDataList = new List<AssignedAvailabilityData>();    
            foreach(var cat in allDates)
            {
                AssignedAvailabilityDataList.Add(new AssignedAvailabilityData
                {
                    AvailableTimeDateID = cat.ID,
                    DateTime = cat.Availabilty,
                    Assigned = appointments.Contains(cat.ID)
                });

            }
        }
        public void UpdateAvailableHoursAndDates(Proiect_Nagy_CristinaContextV2 context, string[] selectedDatesAndHours, Children childrenToUpdate)
        {
            if(selectedDatesAndHours == null)
            {
                childrenToUpdate.Appointments = new List<Appointment>();
                return;
            }
            var selectedAvailableDatesAndHoursHS = new HashSet<string>(selectedDatesAndHours);
            var appointments = new HashSet<int>(childrenToUpdate.Appointments.Select(c => c.AvailableTimeDate.ID));

            foreach (var cat in context.AvailableTimeDate)
            {
                if (selectedAvailableDatesAndHoursHS.Contains(cat.ID.ToString()))
                {
                    if (!appointments.Contains(cat.ID))
                    {
                        childrenToUpdate.Appointments.Add(new Appointment
                        {
                            ChildrenID = childrenToUpdate.ID,
                            AvailableTimeDateID = cat.ID
                        }) ;

                    }
                }
                else
                {
                    if (appointments.Contains(cat.ID))
                    {
                        Appointment remove = childrenToUpdate
                            .Appointments
                            .SingleOrDefault(i => i.AvailableTimeDateID == cat.ID);
                        context.Remove(remove);
                    }
                }
            }
        }
    }
}
