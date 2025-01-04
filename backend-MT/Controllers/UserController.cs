using backend_MT.Exceptions;
using backend_MT.Models.DTOs.UserDTOs;
using backend_MT.Service.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using backend_MT.Exceptions;
using backend_MT.Models.DTOs;
using backend_MT.Services;

namespace backend_MT.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserService _userService;
		public UserController(IUserService userService)
		{
			_userService = userService;
		}
		[Consumes("multipart/form-data")]
		[HttpPost("register")]
		[AllowAnonymous]
		public async Task<IActionResult> Register([FromForm] RegisterDTO user)
		{

			var result = await _userService.RegisterAsync(user);
			if (result.Succeeded)
			{
				return Ok();
			}
			else
			{
				var errors = result.Errors.Select(e => e.Description);
				return BadRequest(errors);
			}
		}
		[HttpPost("login")]
		[AllowAnonymous]
		public async Task<IActionResult> Login(LoginDTO user)
		{
			try
			{
				var result = await _userService.LoginAsync(user);
				return Ok(new { Token = result, Message = $"Autentificat ca {user.username}" });
			}
			catch (LockedOutException e)
			{
				return BadRequest(e.Message);
			}
			catch (WrongDetailsException e)
			{
				return NotFound(e.Message);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}
		[HttpGet("confirmEmail")]
		[AllowAnonymous]
		public async Task<IActionResult> ConfirmEmail(string username, string token)
		{
			try
			{
				await _userService.ConfirmEmail(username, token);
				return Ok();
			}
			catch (NotFoundException e)
			{
				return NotFound(e.Message);
			}
		}
		[HttpPost("getUserDetails")]
		[AllowAnonymous]
		public async Task<IActionResult> getUserDetails(string username)
		{
			try
			{
				var result = await _userService.getUserDetails(username);
				return Ok(result);
			}
			catch (NotFoundException e)
			{
				return NotFound(e.Message);
			}
		}
		//[HttpPost("uploadPhoto")]
		//[AllowAnonymous]
		//public async Task<IActionResult> uploadPhoto([FromForm] RegisterDTO user)
		//{
		//	try
		//	{
		//		var res = await _userService.uploadPhoto(user);
		//		if (res == true)
		//			return Ok(res);
		//		else
		//			return BadRequest(res);
		//	}
		//	catch (Exception e)
		//	{
		//		return BadRequest(e.Message);
		//	}
		//}
		[HttpPost("sendConfirmationEmail")]
		[AllowAnonymous]
		public async Task<IActionResult> sendConfirmationEmail([FromForm] RegisterDTO user)
		{
			try
			{
				await _userService.sendConfirmationEmail(user);
				return Ok();
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}
		[HttpPost("forgotPassword")]
		[AllowAnonymous]
		public async Task<IActionResult> forgotPassword(ForgotPasswordDTO user)
		{
			Console.WriteLine(user.username);
			Console.WriteLine(user.email);
			try
			{
				await _userService.forgotPassword(user);
				return Ok();
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}
		[HttpPost("resetPassword")]
		[AllowAnonymous]
		public async Task<IActionResult> resetPassword(ResetPasswordDTO user)
		{
			try
			{
				await _userService.resetPassword(user);
				return Ok();
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}
		[HttpGet("getUser")]
		[AllowAnonymous]
		public async Task<IActionResult> getUser(string username)
		{
			try
			{
				var result = await _userService.getUserProfile(username);
				return Ok(result);
			}
			catch (NotFoundException e)
			{
				return NotFound(e.Message);
			}
		}
		//[HttpPost("uploadDocument")]
		//[AllowAnonymous]
		//public async Task<IActionResult> uploadDocument(string username, string document, IFormFile file)
		//{
		//	try
		//	{
		//		await _userService.uploadDocument(username, document, file);
		//		return Ok();
		//	}
		//	catch (Exception e)
		//	{
		//		return BadRequest(e.Message);
		//	}
		//}
		[HttpGet("getById")]
		[AllowAnonymous]
		public async Task<IActionResult> getUserById(int id)
		{
			try
			{
				var result = await _userService.getUserById(id);
				return Ok(result);
			}
			catch (NotFoundException e)
			{
				return NotFound(e.Message);
			}
		}
	}
}
