using System.ComponentModel.DataAnnotations;

namespace backend_MT.Models
{
    public class Mesaj
    {
        [Key] public int MesajId { get; set; }

        [Required] [MaxLength(2000)] public string MesajText { get; set; }

        [Required] [MaxLength(10)] public string TipMesaj { get; set; } // "Privat" or "Grup"

        [Required] public string EmitatorId { get; set; }
        public virtual Elev Emitator { get; set; }

        [Required] public string ReceptorId { get; set; }
        public virtual Elev Receptor { get; set; }
    }
}