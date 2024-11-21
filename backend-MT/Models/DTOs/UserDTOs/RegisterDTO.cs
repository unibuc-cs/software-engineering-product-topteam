namespace backend_MT.Models.DTOs
{
	public class RegisterDTO
	{
		public string parola { get; set; }
		public string nume { get; set; }
		public string prenume { get; set; }
		public string email { get; set; }
		public string nrTelefon { get; set; }
		public DateTime dataNasterii { get; set; }
		public IFormFile pozaProfil { get; set; }
	}
}
