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

		[HttpGet("Owner/GetSkills")]
		public async Task<ActionResult<List<GetSkill>>> GetSkillsOwner()
		{
			return await _skillService.GetSkillsOwner();
		}

		[HttpGet("Viewer/GetSkills")]
		public async Task<ActionResult<List<GetSkill>>> GetSkillsViewer()
		{
			return await _skillService.GetSkillsViewer();
		}
	}
}
