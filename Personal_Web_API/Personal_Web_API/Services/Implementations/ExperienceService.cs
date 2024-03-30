using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Personal_Web_API.Dtos;
using Personal_Web_API.Mappers;
using Personal_Web_API.Models;
using Personal_Web_API.Services.Interfaces;

namespace Personal_Web_API.Services.Implementations
{
	public class ExperienceService : IExperienceService
	{
		private readonly PersonalWebDbContext _context;

        public ExperienceService(PersonalWebDbContext context)
        {
			_context = context;
		}

		public async Task<ActionResult<List<GetExperience>>> GetExperience(int userId)
		{
			IQueryable<Experience> query = _context.Experiences;
			query = query.Where(e => e.ExperienceUserId == userId);

			List<Experience> objects = await query.ToListAsync();
			List<GetExperience> dtos = objects.Select(obj => ExperienceMapper.AsDto(obj)).ToList();

			return dtos;
		}
	}
}
