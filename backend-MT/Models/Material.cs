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
        public int userId { get; set; }
        public virtual User user { get; set; }
    }
}