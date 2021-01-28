using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_Nagy_Cristina.Data;
using Proiect_Nagy_Cristina.Models;

namespace Proiect_Nagy_Cristina.Pages.AvailableTimeDates
{
    public class CreateModel : PageModel
    {
        private readonly Proiect_Nagy_Cristina.Data.Proiect_Nagy_CristinaContextV2 _context;

        public CreateModel(Proiect_Nagy_Cristina.Data.Proiect_Nagy_CristinaContextV2 context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public AvailableTimeDate AvailableTimeDate { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.AvailableTimeDate.Add(AvailableTimeDate);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
