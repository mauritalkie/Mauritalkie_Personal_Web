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

		[HttpGet("Owner/GetAboutMe"), Authorize(Roles = "Admin, User")]
		public async Task<ActionResult<List<GetAboutMe>>> GetAboutMeOwner()
		{
			return await _aboutMeService.GetAboutMeOwner();
		}

		[HttpGet("Viewer/GetAboutMe")]
		public async Task<ActionResult<List<GetAboutMe>>> GetAboutMeVieer()
		{
			return await _aboutMeService.GetAboutMeViewer();
		}
	}
}
