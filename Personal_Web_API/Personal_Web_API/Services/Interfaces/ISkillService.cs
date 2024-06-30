using Microsoft.AspNetCore.Mvc;
using Personal_Web_API.Dtos;

namespace Personal_Web_API.Services.Interfaces
{
	public interface ISkillService
	{
		public Task<ActionResult<List<GetSkill>>> GetSkillsOwner();
		public Task<ActionResult<List<GetSkill>>> GetSkillsViewer();
	}
}
