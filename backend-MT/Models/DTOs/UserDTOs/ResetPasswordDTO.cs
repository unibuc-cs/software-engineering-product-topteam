namespace backend_MT.Models.DTOs.UserDTOs
{
	public class ResetPasswordDTO
	{
		public string username { get; set; }
		public string token { get; set; }
		public string password { get; set; }
	}
}
