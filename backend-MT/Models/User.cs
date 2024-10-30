using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace backend_MT.Models
{
    public class Elev : IdentityUser
    {
        [Required]
        [MaxLength(50)]
        public string Nume { get; set; }

        [Required]
        [MaxLength(50)]
        public string Prenume { get; set; }

        public string Clasa { get; set; }

        public string Poza { get; set; }
    }
}
