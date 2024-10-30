using System.ComponentModel.DataAnnotations;

namespace backend_MT.Models
{
    public class RaspunsTema
    {
        [Key]
        public int RaspunsTemaId { get; set; }

        [MaxLength(500)]
        public string Fisier { get; set; }

        [Range(0, 100)]
        public int Punctaj { get; set; }

        [Required]
        public int TemaId { get; set; }
        public virtual Tema Tema { get; set; }
    }
}