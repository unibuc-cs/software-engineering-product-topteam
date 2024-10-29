using System.ComponentModel.DataAnnotations;

namespace backend_MT.Models
{
    public class Notificare
    {
        [Key]
        public int NotificareId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Titlu { get; set; }

        [MaxLength(1000)]
        public string Mesaj { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [MaxLength(50)]
        public string TipNotificare { get; set; }

        [Required]
        public string ReceptorId { get; set; }
        public virtual Elev Receptor { get; set; }
    }
}