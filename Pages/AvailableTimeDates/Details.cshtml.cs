using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Nagy_Cristina.Data;
using Proiect_Nagy_Cristina.Models;

namespace Proiect_Nagy_Cristina.Pages.AvailableTimeDates
{
    public class DetailsModel : PageModel
    {
        private readonly Proiect_Nagy_Cristina.Data.Proiect_Nagy_CristinaContextV2 _context;

        public DetailsModel(Proiect_Nagy_Cristina.Data.Proiect_Nagy_CristinaContextV2 context)
        {
            _context = context;
        }

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
    }
}
