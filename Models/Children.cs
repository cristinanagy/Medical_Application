using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect_Nagy_Cristina.Models
{
    public class Children
    {
        [Display(Name = "Children ID")]
        public int ID { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = "Prenumele parintelui trebuie sa contina doar litere "), Required]
        [Display(Name = "Parent Name")]
        public string FirstName { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+$", ErrorMessage = "Numele parintelui trebuie sa contina doar litere "), Required]
        [Display(Name = "Child Name")]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [RegularExpression(@"^\d{13}$", ErrorMessage = "CNP-ul copilului trebuie sa contina 13 cifre "), Required, StringLength(13)]
        [Display(Name = "CNP Child")]
        public string CNP { get; set; }
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Numarul de telefon al parintelui trebuie sa contina 10 cifre "), Required,  StringLength(10)]
        [Display(Name = "Phone Number(Parent)")]
        public string PhoneNumber { get; set; }
        [Required]
        public bool Insurance { get; set; }

        public int DoctorID { get; set; }
        public Doctor Doctor { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
