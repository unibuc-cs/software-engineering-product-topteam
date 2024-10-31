namespace backend_MT.Models.DTOs
{
    public class MesajDTO
    {
        public string mesajText { get; set; }
        public string tipMesaj { get; set; } // "Privat" or "Grup"
        public int emitatorId { get; set; }
        public int receptorId { get; set; }
    }
}
