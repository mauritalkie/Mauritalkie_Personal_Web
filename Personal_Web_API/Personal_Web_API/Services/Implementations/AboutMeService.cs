using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Personal_Web_API.Dtos;
using Personal_Web_API.Mappers;
using Personal_Web_API.Models;
using Personal_Web_API.Services.Interfaces;

namespace Personal_Web_API.Services.Implementations
{
	public class AboutMeService : IAboutMeService
	{
		private readonly PersonalWebDbContext _context;

		public AboutMeService(PersonalWebDbContext context)
		{
			_context = context;
		}

		public async Task<ActionResult<List<GetAboutMe>>> GetAboutMe(int userId)
		{
			IQueryable<AboutMe> query = _context.AboutMes;
			query = query.Where(a => a.AboutMeUserId == userId);

			List<AboutMe> objects = await query.ToListAsync();
			List<GetAboutMe> dtos = objects.Select(obj => AboutMeMapper.AsDto(obj)).ToList();

			return dtos;
		}
	}
}
