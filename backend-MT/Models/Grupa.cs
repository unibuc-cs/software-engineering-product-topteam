using System.ComponentModel.DataAnnotations;

namespace backend_MT.Models
{
    public class Grupa
    {
        [Key]
        public int GrupaId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nume { get; set; }

        [MaxLength(50)]
        public string NivelStudiu { get; set; }

        [MaxLength(200)]
        public string LinkMeet { get; set; }

        [Required]
        public string ProfesorId { get; set; }
        public virtual Profesor Profesor { get; set; }

        [Required]
        public int CursId { get; set; }
        public virtual Curs Curs { get; set; }
    }
}