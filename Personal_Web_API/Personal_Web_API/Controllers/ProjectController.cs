using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Personal_Web_API.Dtos;
using Personal_Web_API.Models;
using Personal_Web_API.Services.Interfaces;

namespace Personal_Web_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProjectController : ControllerBase
	{
		private readonly IProjectService _projectService;

		public ProjectController(IProjectService projectService)
		{
			_projectService = projectService;
		}

		[HttpGet("Owner/GetProjects"), Authorize]
		public async Task<List<GetProject>> GetProjectsOwner()
		{
			return await _projectService.GetProjectsOwner();
		}

		[HttpPost, Authorize]
		public async Task<ActionResult> CreateProject(CreateProject projectDto)
		{
			return await _projectService.CreateProject(projectDto);
		}

		[HttpPut, Authorize]
		public async Task<ActionResult> UpdateProject(UpdateProject projectDto)
		{
			return await _projectService.UpdateProject(projectDto);
		}

		[HttpDelete("{id}"), Authorize]
		public async Task<ActionResult> DeleteProject(int id)
		{
			return await _projectService.DeleteProject(id);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<GetProject>> GetProjectById(int id)
		{
			return await _projectService.GetProjectById(id);
		}

		[HttpGet("Viewer/GetProjects")]
		public async Task<List<GetProject>> GetProjectsViewer()
		{
			return await _projectService.GetProjectsViewer();
		}
	}
}
