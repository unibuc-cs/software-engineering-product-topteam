using System.ComponentModel.DataAnnotations;

namespace backend_MT.Models
{
    public class Prezenta
    {
        [Key]
        public int prezentaId { get; set; }
        public int userId { get; set; }
        public virtual User user { get; set; }
        public int sedintaId { get; set; }
        public virtual Sedinta sedinta { get; set; }

    }
}
