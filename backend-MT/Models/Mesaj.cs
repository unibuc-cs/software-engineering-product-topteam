using System.ComponentModel.DataAnnotations;

namespace backend_MT.Models
{
    public class Mesaj
    {
        [Key] public int mesajId { get; set; }
        public string mesajText { get; set; }
        public string tipMesaj { get; set; } // "Privat" or "Grup"
        public int emitatorId { get; set; }
        public virtual User emitator { get; set; }
        public int receptorId { get; set; }
        public virtual User receptor { get; set; }
    }
}