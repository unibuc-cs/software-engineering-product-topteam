using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace backend_MT.Models
{
    public class User : IdentityUser<int>//Ce e cu ? e doar pentru un rol
    {
        [Key]
        public int userId;
        public string nume { get; set; }
        public string prenume { get; set; }
        //public string username { get; set; }
        public string? nivel { get; set; }
        public string? pozaProfil { get; set; }
        //public string email { get; set; }
        public string nrTelefon { get; set; }
        public ICollection<ParticipareGrupa>? participariGrupa { get; set; }
        public ICollection<Abonament>? abonamente { get; set; }
        public ICollection<Plata>? plati {  get; set; }
        public ICollection<Support>? supporturi { get; set; }
        public ICollection<Mesaj>? mesaje { get; set; }
        public ICollection<Notificare>? notificari { get; set; }
        public ICollection<Feedback>? feedbackuri { get; set; }
        public ICollection<Disponibilitate> disponibilitate { get; set; } //Pentru ambele roluri
        public ICollection<RaspunsTema>? raspunsuriTema {  get; set; }
        public ICollection<Prezenta>? prezente {  get; set; }


        //Atribute profesor
        public ICollection<Grupa>? grupa { get; set; }
        public ICollection<Material>? materiale { get; set; }
        public ICollection<Tema>? teme { get; set; }
        public ICollection<Predare>? predare { get; set; }
        public bool? profesorVerificat {  get; set; }

    }
}
