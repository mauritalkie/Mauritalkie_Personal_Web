using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Personal_Web_API.Dtos;
using Personal_Web_API.Services.Interfaces;

namespace Personal_Web_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FutureProjectController : ControllerBase
	{
		private readonly IFutureProjectService _futureProjectService;

		public FutureProjectController(IFutureProjectService futureProjectService)
		{
			_futureProjectService = futureProjectService;
		}

		[HttpGet("{userId}")]
		public async Task<ActionResult<List<GetFutureProject>>> GetFutureProjects(int userId)
		{
			return await _futureProjectService.GetFutureProjects(userId);
		}
	}
}
