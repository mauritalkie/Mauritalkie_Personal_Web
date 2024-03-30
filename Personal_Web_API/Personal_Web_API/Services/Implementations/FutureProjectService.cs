using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Personal_Web_API.Dtos;
using Personal_Web_API.Mappers;
using Personal_Web_API.Models;
using Personal_Web_API.Services.Interfaces;

namespace Personal_Web_API.Services.Implementations
{
	public class FutureProjectService : IFutureProjectService
	{
		private readonly PersonalWebDbContext _context;

		public FutureProjectService(PersonalWebDbContext context)
		{
			_context = context;
		}

		public async Task<ActionResult<List<GetFutureProject>>> GetFutureProjects(int userId)
		{
			IQueryable<FutureProject> query = _context.FutureProjects;
			query = query.Where(f => f.ProjectUserId == userId);

			List<FutureProject> objects = await query.ToListAsync();
			List<GetFutureProject> dtos = objects.Select(obj => FutureProjectMapper.AsDto(obj)).ToList();

			return dtos;
		}
	}
}
