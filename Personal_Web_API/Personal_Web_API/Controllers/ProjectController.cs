using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Personal_Web_API.Models;

namespace Personal_Web_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProjectController : ControllerBase
	{
		private readonly PersonalWebDbContext _context;

		public ProjectController(PersonalWebDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<List<Project>> GetProjects()
		{
			return await _context.Projects.ToListAsync();
		}

		[HttpPost]
		public async Task<ActionResult> CreateProject(Project project)
		{
			_context.Projects.Add(project);
			await _context.SaveChangesAsync();
			return StatusCode(200, "Success");
		}

		[HttpPut]
		public async Task<ActionResult> UpdateProject(Project project)
		{
			var dbProject = await _context.Projects.FindAsync(project.Id);
			if (dbProject == null) return StatusCode(404, "Not Found");

			dbProject.ProjectName = project.ProjectName;
			dbProject.ProjectUrl = project.ProjectUrl;
			dbProject.ImageUrl = project.ImageUrl;
			dbProject.UpdatedAt = DateTime.Now;

			await _context.SaveChangesAsync();
			return StatusCode(200, "Success");
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteProject(int id)
		{
			var dbProject = await _context.Projects.FindAsync(id);
			if (dbProject == null) return StatusCode(404, "Not Found");

			_context.Projects.Remove(dbProject);
			await _context.SaveChangesAsync();

			return StatusCode(200, "Success");
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Project>> GetProjectById(int id)
		{
			var dbProject = await _context.Projects.FindAsync(id);
			if (dbProject == null) return StatusCode(404, "Not Found");

			return dbProject;
		}
	}
}
