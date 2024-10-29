using System.ComponentModel.DataAnnotations;

namespace backend_MT.Models
{
    public class Curs
    {
        [Key]
        public int CursId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Denumire { get; set; }

        [MaxLength(500)]
        public string Descriere { get; set; }

        public int NrSedinte { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Pretul trebuie sa fie un numar pozitiv.")]
        public decimal Pret { get; set; }
    }
}