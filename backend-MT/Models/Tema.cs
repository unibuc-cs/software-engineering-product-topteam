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
        public int profesorId { get; set; }
        public virtual Profesor profesor { get; set; }
    }
}