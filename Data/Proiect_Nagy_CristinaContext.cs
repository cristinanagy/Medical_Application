using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect_Nagy_Cristina.Models;

namespace Proiect_Nagy_Cristina.Data
{
    public class Proiect_Nagy_CristinaContextV2 : DbContext
    {
        public Proiect_Nagy_CristinaContextV2 (DbContextOptions<Proiect_Nagy_CristinaContextV2> options)
            : base(options)
        {
        }

        public DbSet<Proiect_Nagy_Cristina.Models.Children> Children { get; set; }

        public DbSet<Proiect_Nagy_Cristina.Models.Doctor> Doctor { get; set; }

        public DbSet<Proiect_Nagy_Cristina.Models.AvailableTimeDate> AvailableTimeDate { get; set; }
    }
}
