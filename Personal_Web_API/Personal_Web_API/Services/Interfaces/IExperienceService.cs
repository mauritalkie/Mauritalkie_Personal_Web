using Microsoft.AspNetCore.Mvc;
using Personal_Web_API.Dtos;

namespace Personal_Web_API.Services.Interfaces
{
	public interface IExperienceService
	{
		public Task<ActionResult<List<GetExperience>>> GetExperience(int userId);
	}
}
