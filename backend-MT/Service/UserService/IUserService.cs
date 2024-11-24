using backend_MT.Models.DTOs;
using backend_MT.Models.DTOs.UserDTOs;
using Microsoft.AspNetCore.Identity;
using backend_MT.Models;

namespace backend_MT.Service.UserService
{
	public interface IUserService
	{
		Task<IdentityResult> RegisterAsync(RegisterDTO newUser);
		Task<UserDTO> getUserDetails(string username);
		Task<string> LoginAsync(LoginDTO login);
		Task ConfirmEmail(string username, string token);
		//Task<bool> uploadPhoto(RegisterDTO newUser);
		Task sendConfirmationEmail(RegisterDTO newUser);
		Task resetPassword(ResetPasswordDTO user);
		Task forgotPassword(ForgotPasswordDTO userDTO);
		//Task uploadDocument(string username, string document, IFormFile file);
		Task<UserDTO> getUserProfile(string username);
		Task<UserDTO> getUserById(int id);
	}
}
