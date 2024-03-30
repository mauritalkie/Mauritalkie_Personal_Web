using Microsoft.AspNetCore.Mvc;
using Personal_Web_API.Dtos;
using Personal_Web_API.Models;

namespace Personal_Web_API.Services.Interfaces
{
	public interface IProjectService
	{
		Task<List<GetProject>> GetProjects(int? userId);
		Task<ActionResult> CreateProject(CreateProject projectDto);
		Task<ActionResult> UpdateProject(UpdateProject projectDto);
		Task<ActionResult> DeleteProject(int id);
		Task<ActionResult<GetProject>> GetProjectById(int id);
	}
}
