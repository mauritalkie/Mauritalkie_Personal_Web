using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Personal_Web_API.Dtos;
using Personal_Web_API.Mappers;
using Personal_Web_API.Models;
using Personal_Web_API.Services.Interfaces;

namespace Personal_Web_API.Services.Implementations
{
	public class ProjectService : IProjectService
	{
		private readonly PersonalWebDbContext _context;

		public ProjectService(PersonalWebDbContext context)
		{
			_context = context;
		}

		public async Task<ActionResult> CreateProject(CreateProject projectDto)
		{
			Project project = ProjectMapper.AsObject(projectDto);

			_context.Projects.Add(project);
			await _context.SaveChangesAsync();

			return new JsonResult("Project created successfully");
		}

		public async Task<ActionResult> DeleteProject(int id)
		{
			var dbProject = await _context.Projects.FindAsync(id);
			if (dbProject == null) return new JsonResult("Project not found");

			_context.Projects.Remove(dbProject);
			await _context.SaveChangesAsync();

			return new JsonResult("Project deleted successfully");
		}

		public async Task<ActionResult<GetProject>> GetProjectById(int id)
		{
			var dbProject = await _context.Projects.FindAsync(id);
			if (dbProject == null) return new JsonResult("Project not found");

			return ProjectMapper.AsDto(dbProject);
		}

		public async Task<List<GetProject>> GetProjects(int? userId = null)
		{
			IQueryable<Project> query = _context.Projects;

			if (userId.HasValue)
			{
				query = query.Where(p => p.ProjectUserId == userId);
			}

			List<Project> objects = await query.ToListAsync();
			List<GetProject> dtos = objects.Select(obj => ProjectMapper.AsDto(obj)).ToList();
			return dtos;
		}

		public async Task<ActionResult> UpdateProject(UpdateProject project)
		{
			var dbProject = await _context.Projects.FindAsync(project.Id);
			if (dbProject == null) return new JsonResult("Project not found");

			dbProject.ProjectName = project.ProjectName;
			dbProject.ProjectUrl = project.ProjectUrl;
			dbProject.ImageUrl = project.ImageUrl;
			dbProject.UpdatedAt = DateTime.Now;

			await _context.SaveChangesAsync();
			return new JsonResult("Project updated successfully");
		}
	}
}
