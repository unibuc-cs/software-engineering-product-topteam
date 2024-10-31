using System.ComponentModel.DataAnnotations;

namespace backend_MT.Models
{
    public class ParticipareGrupa
    {
        [Key]
        public int participareGrupaId { get; set; }
        public int userId { get; set; }
        public virtual User user { get; set; }
        public int grupaId { get; set; }
        public virtual Grupa grupa { get; set; }
    }
}
