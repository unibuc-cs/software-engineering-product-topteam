namespace backend_MT.Models.DTOs
{
	public class RegisterDTO
	{
		public string parola { get; set; }
		public string nume { get; set; }
		public string prenume { get; set; }
		public string username { get; set; }
		public string? nivel { get; set; }
		public string pozaProfil { get; set; }
		public string email { get; set; }
		public string nrTelefon { get; set; }
		public bool? profesorVerificat { get; set; }
	}
}
