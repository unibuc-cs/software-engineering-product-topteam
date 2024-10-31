using System.ComponentModel.DataAnnotations;

namespace backend_MT.Models
{
    public class Support
    {
        [Key]
        public int supportId { get; set; }
        public string mesaj { get; set; }
        public int userId { get; set; }
        public virtual User user { get; set; }
    }
}