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

		[HttpGet("DisplayInfoViewer/{userId}")]
		public async Task<ActionResult<List<DisplayUserInfo>>> DisplayUserInfoViewer(int userId)
		{
			return await _userService.DisplayUserInfoViewer(userId);
		}

		[HttpGet("DisplayInfoOwner"), Authorize]
		public async Task<ActionResult<List<DisplayUserInfo>>> DisplayUserInfoOwner()
		{
			return await _userService.DisplayUserInfoOwner();
		}

		[HttpPost("Create")]
		public async Task<ActionResult> CreateUser(CreateUser userDto)
		{
			return await _userService.CreateUser(userDto);
		}

		[HttpPost("Login")]
		public async Task<ActionResult<SessionUser>> Login(LoginUser userDto)
		{
			return await _userService.Login(userDto);
		}

		[HttpGet("GetMyName"), Authorize]
		public ActionResult<string> GetMyName()
		{
			return Ok(_userService.GetMyName());
		}

		[HttpGet("GetMyId"), Authorize]
		public ActionResult<int> GetMyId()
		{
			return Ok(_userService.GetMyId());
		}

		[HttpPut("Update"), Authorize]
		public async Task<ActionResult> UpdateUser(UpdateUser userDto)
		{
			return await _userService.UpdateUser(userDto);
		}

		[HttpGet("GetCurrentUser"), Authorize]
		public async Task<ActionResult<GetUser>> GetCurrentUser()
		{
			return await _userService.GetCurrentUser();
		}
	}
}
