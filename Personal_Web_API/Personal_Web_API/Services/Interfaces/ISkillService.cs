using Microsoft.AspNetCore.Mvc;
using Personal_Web_API.Dtos;

namespace Personal_Web_API.Services.Interfaces
{
	public interface ISkillService
	{
		public Task<ActionResult<List<GetSkill>>> GetSkills(int userId);
	}
}
