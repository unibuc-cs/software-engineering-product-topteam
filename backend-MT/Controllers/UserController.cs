using backend_MT.Exceptions;
using backend_MT.Models;
using backend_MT.Models.DTOs.UserDTOs;
using backend_MT.Service.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace backend_MT.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterDTO user)
        {
            if (user == null)
            {
                return BadRequest(new { Message = "User data is required" });
            }

            var result = await _userService.RegisterAsync(user);
            if (result.Succeeded)
            {
                return Ok(new { Message = "User registered successfully" });
            }
            else
            {
                var errors = result.Errors.Select(e => e.Description).ToList();
                return BadRequest(new { Errors = errors });
            }
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult> Login([FromBody] LoginDTO user)
        {
            try
            {
                var loggedIn = await _userService.LoginAsync(user);
                Console.WriteLine(loggedIn.Token);
                if (!string.IsNullOrEmpty(loggedIn.Token))
                {
                    Response.Cookies.Append("jwt", loggedIn.Token, new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.None,
                        Expires = DateTimeOffset.UtcNow.AddMinutes(30)
                    });
					Console.WriteLine(loggedIn.Message); // I get here
					Console.WriteLine($"Returning token: {loggedIn.Token}");
					Console.WriteLine($"Response object: {JsonConvert.SerializeObject(loggedIn)}");

					return Ok( new { Id = loggedIn.Id, Message = loggedIn.Message, Token = loggedIn.Token});
                }
                else
                {
                    return Unauthorized("Invalid login attempt");
                }
            }
            catch (LockedOutException e)
            {
                return BadRequest(e.Message);
            }
            catch (WrongDetailsException e)
            {
                return Unauthorized(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("currentUser")]
        public async Task<IActionResult> currentUser()
        {
            return Ok(await _userService.GetCurrentUserInfoAsync());
        }

        [HttpGet("getUserByUsername")]
        public async Task<ActionResult<User>> getUserByUsername(string username)
        {
            return Ok(await _userService.GetUserByUsername(username));
        }


		[HttpGet("getUserById")]
		public async Task<ActionResult<User>> getUserById(int id)
		{
			return Ok(await _userService.GetUserById(id));
		}


		[HttpGet("getAddedGroups")]
		public async Task<ActionResult<ICollection<User>>> GetAddedGroups(int id)
		{
			return Ok(await _userService.GetAddedGroups(id));
		}
		//[HttpGet("")]
	}
}
