using System.ComponentModel.DataAnnotations;

namespace backend_MT.Models
{
    public class Support
    {
        [Key]
        public int supportId { get; set; }
        public string mesaj { get; set; }
        public int elevId { get; set; }
        public virtual User elev { get; set; }
    }
}