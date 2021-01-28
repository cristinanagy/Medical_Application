using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_Nagy_Cristina.Data;
using Proiect_Nagy_Cristina.Models;

namespace Proiect_Nagy_Cristina.Pages.Childrens
{
    public class CreateModel : ChildrenAppointmentsPageModel
    {
        private readonly Proiect_Nagy_Cristina.Data.Proiect_Nagy_CristinaContextV2 _context;

        public CreateModel(Proiect_Nagy_Cristina.Data.Proiect_Nagy_CristinaContextV2 context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["DoctorID"] = new SelectList(_context.Set<Doctor>(), "ID", "Code");

            var children = new Children();
            children.Appointments = new List<Appointment>();
            PopulateAssignedAvailabilityData(_context, children);

            return Page();
        }

        [BindProperty]
        public Children Children { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedAppointments)
        {
            var newChildren = new Children();
            if (selectedAppointments != null)
            {
                newChildren.Appointments = new List<Appointment>();
                foreach (var cat in selectedAppointments)
                {
                    var catToAdd = new Appointment
                    {
                        AvailableTimeDateID = int.Parse(cat)
                    };
                    newChildren.Appointments.Add(catToAdd);

                }
            }
            if (await TryUpdateModelAsync<Children>(
                    newChildren,
                    "Children",
                     i => i.FirstName, i => i.LastName, i => i.Address, i => i.CNP, i => i.PhoneNumber,
                       i => i.Insurance, i => i.DoctorID))
            {
                _context.Children.Add(newChildren);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedAvailabilityData(_context, newChildren);
            return Page();

        }
    }
}
