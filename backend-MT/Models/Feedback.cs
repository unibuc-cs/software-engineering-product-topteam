using System.ComponentModel.DataAnnotations;

namespace backend_MT.Models
{
    public class Feedback
    {
        [Key]
        public int FeedbackId { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Mesaj { get; set; }

        [Required]
        public int SedintaId { get; set; }
        public virtual Sedinta Sedinta { get; set; }

        [Required]
        public string ElevId { get; set; } 
        public virtual User Elev { get; set; }
    }
}