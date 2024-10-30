using System.ComponentModel.DataAnnotations;

namespace backend_MT.Models
{
    public class Support
    {
        [Key]
        public int SupportId { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Mesaj { get; set; }

        [Required]
        public string ElevId { get; set; }
        public virtual Elev Elev { get; set; }
    }
}