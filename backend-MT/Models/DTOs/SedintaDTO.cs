namespace backend_MT.Models.DTOs
{
    public class SedintaDTO
    {
        public string titlu { get; set; }
        public DateTime zi { get; set; }
        public DateTime oraIncepere { get; set; }
        public DateTime oraIncheiere { get; set; }
        public int grupaId { get; set; }
		public ICollection<int>? userEleviId { get; set; }
	}
}
