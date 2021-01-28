using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Nagy_Cristina.Data;
using Proiect_Nagy_Cristina.Models;

namespace Proiect_Nagy_Cristina.Pages.Childrens
{
    public class EditModel : ChildrenAppointmentsPageModel
    {
        private readonly Proiect_Nagy_Cristina.Data.Proiect_Nagy_CristinaContextV2 _context;

        public EditModel(Proiect_Nagy_Cristina.Data.Proiect_Nagy_CristinaContextV2 context)
        {
            _context = context;
        }

        [BindProperty]
        public Children Children { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Children = await _context.Children
                .Include(b=>b.Doctor)
                .Include(b=>b.Appointments).ThenInclude(b=>b.AvailableTimeDate)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Children == null)
            {
                return NotFound();
            }

            PopulateAssignedAvailabilityData(_context, Children);
            ViewData["DoctorID"] = new SelectList(_context.Set<Doctor>(), "ID", "Code");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedAppointments)
        {
            if (id == null)
            {
                return NotFound();
            }
            var childrenToUpdate = await _context.Children
                .Include(i => i.Doctor)
                .Include(i => i.Appointments)
                .ThenInclude(i => i.AvailableTimeDate)
                .FirstOrDefaultAsync(s => s.ID == id);

            if (childrenToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Children>(
                childrenToUpdate,
                "Children",
                i => i.FirstName, i => i.LastName, i => i.Address, i => i.CNP, i => i.PhoneNumber,
                i => i.Insurance, i => i.Doctor))
            {
                UpdateAvailableHoursAndDates(_context, selectedAppointments, childrenToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateAvailableHoursAndDates(_context, selectedAppointments, childrenToUpdate);
            PopulateAssignedAvailabilityData(_context, childrenToUpdate);
            return Page();

        }
    }
}
