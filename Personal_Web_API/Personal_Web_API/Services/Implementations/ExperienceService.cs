using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Personal_Web_API.Dtos;
using Personal_Web_API.Mappers;
using Personal_Web_API.Models;
using Personal_Web_API.Services.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Personal_Web_API.Services.Implementations
{
	public class ExperienceService : IExperienceService
	{
		private readonly PersonalWebDbContext _context;
		private readonly IUserService _userService;

        public ExperienceService(PersonalWebDbContext context, IUserService userService)
        {
			_context = context;
			_userService = userService;
		}

		public async Task<ActionResult<List<GetExperience>>> GetExperienceOwner()
		{
			int userId = int.Parse(_userService.GetMyId());
			IQueryable<Experience> query = _context.Experiences;
			query = query.Where(e => e.ExperienceUserId == userId);

			List<Experience> objects = await query.ToListAsync();
			List<GetExperience> dtos = objects.Select(obj => ExperienceMapper.AsDto(obj)).ToList();
			return dtos;
		}

		public async Task<ActionResult<List<GetExperience>>> GetExperienceViewer()
		{
			List<Experience> objects = await _context.Experiences.ToListAsync();
			List<GetExperience> dtos = objects.Select(obj => ExperienceMapper.AsDto(obj)).ToList();
			return dtos;
		}
	}
}
