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

		[HttpGet("{userId}")]
		public async Task<ActionResult<List<GetExperience>>> GetExperience(int userId)
		{
			return await _experienceService.GetExperience(userId);
		}
	}
}
