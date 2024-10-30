using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace backend_MT.Models
{
    public class Profesor : IdentityUser
    {
        [Key]
        public int profesorId { get; set; }
        public string nume { get; set; }
        public string prenume { get; set; }
        public ICollection<Grupa> grupuri {  get; set; }
        public ICollection<Material> materiale { get; set; }
        public ICollection<Notificare> notificari { get; set; }
        public ICollection<Tema> teme {  get; set; }
        public ICollection<Predare> predare {  get; set; }
        public ICollection<Mesaj> mesaje { get; set; }
    }
}