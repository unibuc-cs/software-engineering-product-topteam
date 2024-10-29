using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_MT.Models
{
    public class Sedinta
    {
        [Key]
        public int SedintaId { get; set; }

        [Required]
        public string Titlu { get; set; }

        [Required]
        public DateTime Zi { get; set; }

        [Required]
        public DateTime OraIncepere { get; set; }

        [Required]
        public DateTime OraIncheiere { get; set; }

        [ForeignKey("Grupa")]
        public int GrupaId { get; set; }
        public virtual Grupa Grupa { get; set; }
    }
}