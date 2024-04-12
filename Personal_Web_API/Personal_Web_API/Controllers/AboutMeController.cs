using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Personal_Web_API.Dtos;
using Personal_Web_API.Services.Interfaces;

namespace Personal_Web_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AboutMeController : ControllerBase
	{
		private readonly IAboutMeService _aboutMeService;

		public AboutMeController(IAboutMeService aboutMeService)
		{
			_aboutMeService = aboutMeService;
		}

		[HttpGet("{userId}"), Authorize(Roles = "Admin, User")]
		public async Task<ActionResult<List<GetAboutMe>>> GetAboutMe(int userId)
		{
			return await _aboutMeService.GetAboutMe(userId);
		}
	}
}
