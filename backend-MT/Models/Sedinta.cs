using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_MT.Models
{
    public class Sedinta
    {
        [Key]
        public int sedintaId { get; set; }
        public string titlu { get; set; }
        public DateTime zi { get; set; }
        public DateTime oraIncepere { get; set; }
        public DateTime oraIncheiere { get; set; }
        public int grupaId { get; set; }
        public virtual Grupa grupa { get; set; }
        public ICollection<Prezenta> prezente {  get; set; }
    }
}