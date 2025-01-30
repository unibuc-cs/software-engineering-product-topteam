namespace backend_MT.Models.DTOs.UserDTOs
{
	public class UserDTO
	{
		public string nume { get; set; }
		public string prenume { get; set; }
		public string? nivel { get; set; }
		public string pozaProfil { get; set; }
		public string nrTelefon { get; set; }
		public ICollection<int>? grupeAsociateElevId { get; set; }
		public ICollection<int>? prezenteId {  get; set; }
		public int plataId { get; set; }

		public bool? profesorVerificat { get; set; }


		public string UserName { get; set; }
		public string Email { get; set; }
	}
}
