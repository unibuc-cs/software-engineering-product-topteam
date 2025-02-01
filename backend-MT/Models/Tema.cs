using System.ComponentModel.DataAnnotations;

namespace backend_MT.Models
{
    public class Tema
    {
        [Key]
        public int temaId { get; set; }
        public string titlu { get; set; }
        public string descriere { get; set; }
        public string fisier { get; set; }
        public int userId { get; set; }
        public virtual User user { get; set; }
        public ICollection<RaspunsTema>? raspunsuriTema {  get; set; }
    }
}