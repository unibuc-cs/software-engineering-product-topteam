using System.ComponentModel.DataAnnotations;

namespace backend_MT.Models
{
    public class Feedback
    {
        [Key]
        public int feedbackId { get; set; }
        public string mesaj { get; set; }
        public int sedintaId { get; set; }
        public virtual Sedinta sedinta { get; set; }
        public int userId { get; set; } 
        public virtual User elev { get; set; }
    }
}