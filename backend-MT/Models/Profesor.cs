using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace backend_MT.Models
{
    public class Profesor : IdentityUser
    {

        [Required]
        [MaxLength(50)]
        public string Nume { get; set; }

        [Required]
        [MaxLength(50)]
        public string Prenume { get; set; }

        [Phone]
        public string Telefon { get; set; }

        public int NrSedinte { get; set; }
    }
}