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
	}
}
