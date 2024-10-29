using System.ComponentModel.DataAnnotations;

namespace backend_MT.Models
{
    public class Material
    {
        [Key]
        public int IdMaterial { get; set; }

        public string Titlu { get; set; }  

        public string Descriere { get; set; }

        public string Fisier { get; set; }

        public virtual Profesor Profesor { get; set; }

    }
}
