using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Personal_Web_API.Dtos;
using Personal_Web_API.Services.Interfaces;

namespace Personal_Web_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SkillController : ControllerBase
	{
		private readonly ISkillService _skillService;

		public SkillController(ISkillService skillService)
		{ 
			_skillService = skillService;
		}

		[HttpGet("{userId}")]
		public async Task<ActionResult<List<GetSkill>>> GetSkills(int userId)
		{
			return await _skillService.GetSkills(userId);
		}
	}
}
