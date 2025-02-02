using backend_MT.Models.DTOs.UserDTOs;
using backend_MT.Models;
using backend_MT.Service.UserService;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static backend_MT.Models.Roles.Role;
using backend_MT.Exceptions;
using AutoMapper;
using backend_MT.Data;

namespace backend_MT.Services
{
    public class UserService : IUserService
    {
		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

		public UserService(UserManager<User> userManager, SignInManager<User> signInManager, IHttpContextAccessor httpContextAccessor, IMapper mapper, ApplicationDbContext context)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _context = context;
		}

		public async Task<IdentityResult> RegisterAsync(RegisterDTO newUser)
        {
            var user = new User
            {
                UserName = newUser.username,
                Email = newUser.email,
                nume = newUser.nume,
                prenume = newUser.prenume,
                PhoneNumber = newUser.nrTelefon,
                pozaProfil = newUser.pozaProfil,
                nivel = newUser.nivel,
                profesorVerificat = false,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, newUser.parola);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, Roles.Elev.ToString());
            }

            return result;
        }

        public async Task<LoggedInDTO> LoginAsync(LoginDTO login)
        {
            var user = await _userManager.FindByNameAsync(login.username);
            if (user == null)
            {
                throw new NotFoundException("User not found");
            }
            if (!user.EmailConfirmed)
            {
                throw new NotFoundException("Email not confirmed. Please check your email for the confirmation link.");
            }

            var result = await _signInManager.PasswordSignInAsync(login.username, login.parola, login.remember, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var roles = await _userManager.GetRolesAsync(user);
				LoggedInDTO loggedIn = new LoggedInDTO
				{
					Token = GenerateToken(user, roles),
					Message = $"Authenticated as {login.username}",
					Id = user.Id
				};
				return loggedIn;
            }
            else if (result.IsLockedOut)
            {
                throw new LockedOutException("Too many failed login attempts. Your account is locked.");
            }
            else
            {
                throw new WrongDetailsException("Incorrect username or password");
            }
        }
        private string GenerateToken(User user, IList<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim("id", user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.nume),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.MobilePhone, user.PhoneNumber)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("rGSSVGNjKoM4qq41wHcssBm4JDzDxfc93rfcAy+id0I="));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "https://localhost:7215/",
                audience: "https://localhost:7215/",
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                notBefore: DateTime.Now,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

		public async Task<UserDTO> GetCurrentUserInfoAsync()
		{
			var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
			if (userId == null)
			{
				throw new NotFoundException("User not found");
			}

			var user = await _userManager.FindByIdAsync(userId);
			if (user == null)
			{
				throw new NotFoundException("User not found");
			}

			return _mapper.Map<UserDTO>(user);
		}

        public async Task<User> GetUserByUsername(string username)
        {
			var user = await _userManager.FindByNameAsync(username);

            return user;
		}


		public async Task<User> GetUserById(int id)
		{
            var user = await _context.user.FindAsync(id);

			return user;
		}

	}
}
