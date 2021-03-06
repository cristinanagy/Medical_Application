﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Nagy_Cristina.Data;
using Proiect_Nagy_Cristina.Models;

namespace Proiect_Nagy_Cristina.Pages.Doctors
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Nagy_Cristina.Data.Proiect_Nagy_CristinaContextV2 _context;

        public IndexModel(Proiect_Nagy_Cristina.Data.Proiect_Nagy_CristinaContextV2 context)
        {
            _context = context;
        }

        public IList<Doctor> Doctor { get;set; }

        public async Task OnGetAsync()
        {
            Doctor = await _context.Doctor.ToListAsync();
        }
    }
}
