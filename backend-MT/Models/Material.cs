using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_MT.Models
{
    public class Material
    {
        [Key]
        public int IdMaterial { get; set; }

        [Required]
        public string Titlu { get; set; }

        public string Descriere { get; set; }

        [ForeignKey("Profesor")]
        public string ProfesorId { get; set; }
        
        public virtual Profesor Profesor { get; set; }
    }
}