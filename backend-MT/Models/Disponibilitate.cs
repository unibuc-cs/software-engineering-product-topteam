using System.ComponentModel.DataAnnotations;

namespace backend_MT.Models
{
    public class Disponibilitate
    {
        [Key]
        public int disponibilitateId { get; set; }
        public DayOfWeek zi { get; set; }
        public TimeSpan oraIncepere { get; set; }
        public int userId { get; set; }
        public virtual User user {  get; set; }
    }
}
