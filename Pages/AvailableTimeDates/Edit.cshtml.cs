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

namespace Proiect_Nagy_Cristina.Pages.AvailableTimeDates
{
    public class EditModel : PageModel
    {
        private readonly Proiect_Nagy_Cristina.Data.Proiect_Nagy_CristinaContextV2 _context;

        public EditModel(Proiect_Nagy_Cristina.Data.Proiect_Nagy_CristinaContextV2 context)
        {
            _context = context;
        }

        [BindProperty]
        public AvailableTimeDate AvailableTimeDate { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AvailableTimeDate = await _context.AvailableTimeDate.FirstOrDefaultAsync(m => m.ID == id);

            if (AvailableTimeDate == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(AvailableTimeDate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AvailableTimeDateExists(AvailableTimeDate.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AvailableTimeDateExists(int id)
        {
            return _context.AvailableTimeDate.Any(e => e.ID == id);
        }
    }
}
