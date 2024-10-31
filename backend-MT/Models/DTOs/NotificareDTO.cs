namespace backend_MT.Models.DTOs
{
    public class NotificareDTO
    {
        public string titlu { get; set; }
        public string mesaj { get; set; }
        public DateTime data { get; set; }
        public string tipNotificare { get; set; }
        public int receptorId { get; set; }//grupId, userId, profesorId
    }
}
