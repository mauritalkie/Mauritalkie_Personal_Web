using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Personal_Web_API.Dtos;
using Personal_Web_API.Mappers;
using Personal_Web_API.Models;
using Personal_Web_API.Services.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Personal_Web_API.Services.Implementations
{
	public class FutureProjectService : IFutureProjectService
	{
		private readonly PersonalWebDbContext _context;
		private readonly IUserService _userService;

		public FutureProjectService(PersonalWebDbContext context, IUserService userService)
		{
			_context = context;
			_userService = userService;
		}

		public async Task<ActionResult<List<GetFutureProject>>> GetFutureProjectsOwner()
		{
			int userId = int.Parse(_userService.GetMyId());
			IQueryable<FutureProject> query = _context.FutureProjects;
			query = query.Where(f => f.ProjectUserId == userId);

			List<FutureProject> objects = await query.ToListAsync();
			List<GetFutureProject> dtos = objects.Select(obj => FutureProjectMapper.AsDto(obj)).ToList();
			return dtos;
		}

		public async Task<ActionResult<List<GetFutureProject>>> GetFutureProjectsViewer()
		{
			List<FutureProject> objects = await _context.FutureProjects.ToListAsync();
			List<GetFutureProject> dtos = objects.Select(obj => FutureProjectMapper.AsDto(obj)).ToList();
			return dtos;
		}
	}
}
