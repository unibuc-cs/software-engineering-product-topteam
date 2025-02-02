using backend_MT.Models.DTOs;
using backend_MT.Models.DTOs.UserDTOs;
using Microsoft.AspNetCore.Identity;
using backend_MT.Models;

namespace backend_MT.Service.UserService
{
	public interface IUserService
	{
        Task<IdentityResult> RegisterAsync(RegisterDTO newUser);
        Task<LoggedInDTO> LoginAsync(LoginDTO login);
		Task<User> GetUserByUsername(string username);
		Task<User> GetUserById(int id);
		Task<UserDTO> GetCurrentUserInfoAsync();
		Task<ICollection<Grupa>> GetAddedGroups(int userId);
		Task<bool> AddGroups(int userId, ICollection<int> groupIds);
	}
}
