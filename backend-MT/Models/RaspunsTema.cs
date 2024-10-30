using System.ComponentModel.DataAnnotations;

namespace backend_MT.Models
{
    public class RaspunsTema
    {
        [Key]
        public int raspunsTemaId { get; set; }
        public string fisier { get; set; }
        public int punctaj { get; set; }
        public int temaId { get; set; }
        public virtual Tema tema { get; set; }
        public int userID { get; set; }
        public virtual User user { get; set; }
    }
}