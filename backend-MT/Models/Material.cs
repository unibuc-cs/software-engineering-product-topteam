using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_MT.Models
{
    public class Material
    {
        [Key]
        public int materialId { get; set; }
        public string titlu { get; set; }
        public string descriere { get; set; }
        public int profesorId { get; set; }
        public virtual Profesor profesor { get; set; }
    }
}