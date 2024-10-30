using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_MT.Models
{
    public class Plata
    {
        [Key]
        public int PlataId { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Suma trebuie sa fie un numar pozitiv.")]
        public decimal Suma { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Required]
        [ForeignKey("Elev")]
        public string ElevId { get; set; }
        public virtual Elev Elev { get; set; }

        [Required]
        [ForeignKey("Curs")]
        public int CursId { get; set; }
        public virtual Curs Curs { get; set; }
    }
}