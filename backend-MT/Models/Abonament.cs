using System.ComponentModel.DataAnnotations;

namespace backend_MT.Models
{
    public class Abonament
    {
        [Key]
        public int abonamentId { get; set; }
        public int userId { get; set; }
        public virtual User user { get; set; }
        public int sedintaId {  get; set; }
        public virtual Sedinta sedinta { get; set; }
    }
}
