using Microsoft.AspNetCore.Mvc;
using Personal_Web_API.Dtos;

namespace Personal_Web_API.Services.Interfaces
{
	public interface IFutureProjectService
	{
		public Task<ActionResult<List<GetFutureProject>>> GetFutureProjects(int userId);
	}
}
