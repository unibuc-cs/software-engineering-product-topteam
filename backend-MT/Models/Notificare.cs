using System.ComponentModel.DataAnnotations;

namespace backend_MT.Models
{
    public class Notificare
    {
        [Key]
        public int notificareId { get; set; }
        public string titlu { get; set; }
        public string mesaj { get; set; }
        public DateTime data { get; set; }
        public string tipNotificare { get; set; }
        public int receptorId { get; set; }//grupId, userId, profesorId
        public User Receptor { get; set; }
    }
}