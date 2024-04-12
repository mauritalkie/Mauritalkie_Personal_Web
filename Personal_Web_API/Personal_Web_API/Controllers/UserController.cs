using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Personal_Web_API.Dtos;
using Personal_Web_API.Services.Interfaces;

namespace Personal_Web_API.Controllers
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

		[HttpGet("DisplayInfo/{userId}")]
		public async Task<ActionResult<List<DisplayUserInfo>>> DisplayUserInfo(int userId)
		{
			return await _userService.DisplayUserInfo(userId);
		}

		[HttpPost("Create")]
		public async Task<ActionResult> CreateUser(CreateUser userDto)
		{
			return await _userService.CreateUser(userDto);
		}

		[HttpPost("Login")]
		public async Task<ActionResult<string>> Login(LoginUser userDto)
		{
			return await _userService.Login(userDto);
		}

		[HttpGet, Authorize]
		public ActionResult<string> GetMyName()
		{
			return Ok(_userService.GetMyName());
		}
	}
}
