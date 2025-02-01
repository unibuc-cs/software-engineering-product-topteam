namespace backend_MT.Models.DTOs
{
    public class GrupaDTO
    {
        public string nume { get; set; }
        public string nivelStudiu { get; set; }
        public string linkMeet { get; set; }
        public int userProfesorId { get; set; }
        public int cursId { get; set; }
        public ICollection<int>? userEleviId { get; set; }
    }
}
