using backend_MT.Models.DTOs;
using backend_MT.Models.DTOs.UserDTOs;
using Microsoft.AspNetCore.Identity;
using backend_MT.Models;

namespace backend_MT.Service.UserService
{
	public interface IUserService
	{
        Task<IdentityResult> RegisterAsync(RegisterDTO newUser);
        Task<string> LoginAsync(LoginDTO login);
		Task<UserDTO> GetCurrentUserInfoAsync();

	}
}
