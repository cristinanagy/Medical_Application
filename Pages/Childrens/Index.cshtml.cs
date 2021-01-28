using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Nagy_Cristina.Data;
using Proiect_Nagy_Cristina.Models;

namespace Proiect_Nagy_Cristina.Pages.Childrens
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Nagy_Cristina.Data.Proiect_Nagy_CristinaContextV2 _context;

        public IndexModel(Proiect_Nagy_Cristina.Data.Proiect_Nagy_CristinaContextV2 context)
        {
            _context = context;
        }

        public IList<Children> Children { get; set; }
        public ChildrenData ChildrenD { get; set; }
        public int ChildrenID { get; set; }
        public int AvailableTimeDateID { get; set; }

        public async Task OnGetAsync(int? id, int? availableTimeDateID)
        {
            ChildrenD = new ChildrenData();
            ChildrenD.Childrens = await _context.Children
                .Include(b => b.Doctor)
                .Include(b => b.Appointments)
                .ThenInclude(b => b.AvailableTimeDate)
                .AsNoTracking()
                .OrderBy(b => b.FirstName)
                .ToListAsync();
            if (id != null)
            {
                ChildrenID = id.Value;
                Children children = ChildrenD.Childrens
                    .Where(i => i.ID == id.Value).Single();
                ChildrenD.AvailableTimeDates = children.Appointments.Select(s => s.AvailableTimeDate);
            }
        }
    }
}
