using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Personal_Web_API.Dtos;
using Personal_Web_API.Services.Interfaces;

namespace Personal_Web_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ExperienceController : ControllerBase
	{
		private readonly IExperienceService _experienceService;

		public ExperienceController(IExperienceService experienceService)
		{
			_experienceService = experienceService;
		}

		[HttpGet("Owner/GetExperience"), Authorize]
		public async Task<ActionResult<List<GetExperience>>> GetExperienceOwner()
		{
			return await _experienceService.GetExperienceOwner();
		}

		[HttpGet("Viewer/GetExperience")]
		public async Task<ActionResult<List<GetExperience>>> GetExperienceViewer()
		{
			return await _experienceService.GetExperienceViewer();
		}
	}
}
