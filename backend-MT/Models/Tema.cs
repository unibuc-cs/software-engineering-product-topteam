using System.ComponentModel.DataAnnotations;

namespace backend_MT.Models
{
    public class Tema
    {
        [Key]
        public int TemaId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Titlu { get; set; }

        [MaxLength(1000)]
        public string Descriere { get; set; }

        [MaxLength(500)]
        public string Fisier { get; set; }

        [Required]
        public string ProfesorId { get; set; }
        public virtual Profesor Profesor { get; set; }
    }
}