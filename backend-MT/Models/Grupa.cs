using System.ComponentModel.DataAnnotations;

namespace backend_MT.Models
{
    public class Grupa
    {
        [Key]
        public int grupaId { get; set; }
        public string nume { get; set; }
        public string nivelStudiu { get; set; }
        public string linkMeet { get; set; }
        public int userId { get; set; }
        public virtual User user { get; set; }
        public int cursId { get; set; }
        public virtual Curs curs { get; set; }
        public ICollection<ParticipareGrupa> participariGrupa {  get; set; }
    }
}