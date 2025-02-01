using backend_MT.Exceptions;
using backend_MT.Models.DTOs.UserDTOs;
using backend_MT.Service.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Login([FromBody] LoginDTO user)
        {
            try
            {
                var token = await _userService.LoginAsync(user);
                if (!string.IsNullOrEmpty(token))
                {
                    Response.Cookies.Append("jwt", token, new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.None,
                        Expires = DateTimeOffset.UtcNow.AddMinutes(30)
                    });
                    return Ok(new { Message = $"Authenticated as {user.username}", Token = token });
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
    }
}
