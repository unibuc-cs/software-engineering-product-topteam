using System.ComponentModel.DataAnnotations;

namespace backend_MT.Models
{
    public class Predare
    {
        [Key]
        public int predareId {  get; set; }
        public int profesorId { get; set; }
        public virtual Profesor profesor {  get; set; }
        public int cursId { get; set; }
        public virtual Curs curs { get; set; }
    }
}
