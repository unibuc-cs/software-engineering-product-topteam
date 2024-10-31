using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_MT.Models
{
    public class Plata
    {
        [Key]
        public int plataId { get; set; }
        public int suma { get; set; }
        public DateTime data { get; set; }
        public int userId { get; set; }
        public virtual User user { get; set; }
        public int cursId { get; set; }
        public virtual Curs curs { get; set; }
    }
}