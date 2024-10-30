using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace backend_MT.Models
{
    public class User : IdentityUser<int>
    {
        [Key]
        public int userId;
        public string nume { get; set; }
        public string prenume { get; set; }

        public string nivel { get; set; }

        public string pozaProfil { get; set; }
        public ICollection<ParticipareGrupa> participariGrupa { get; set; }
        public ICollection<Abonament> abonamente { get; set; }
        public ICollection<Plata> plati {  get; set; }
        public ICollection<Support> supporturi { get; set; }
        public ICollection<Mesaj> mesaje { get; set; }
        public ICollection<Notificare> notificari { get; set; }
        public ICollection<Feedback> feedbackuri { get; set; }

    }
}
