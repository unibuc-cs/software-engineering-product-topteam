namespace backend_MT.Models.DTOs
{
	public class UserDTO
	{
		public string nume { get; set; }
		public string prenume { get; set; }
		public string? nivel { get; set; }
		public string pozaProfil { get; set; }
		public string email { get; set; }
		public string nrTelefon { get; set; }
		public bool? profesorVerificat { get; set; }
	}
}
