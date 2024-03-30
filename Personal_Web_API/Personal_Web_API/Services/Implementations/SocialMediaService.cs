using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Personal_Web_API.Dtos;
using Personal_Web_API.Mappers;
using Personal_Web_API.Models;
using Personal_Web_API.Services.Interfaces;

namespace Personal_Web_API.Services.Implementations
{
	public class SocialMediaService : ISocialMediaService
	{
		private readonly PersonalWebDbContext _context;

		public SocialMediaService(PersonalWebDbContext context)
		{
			_context = context;
		}

		public async Task<ActionResult<List<GetSocialMedia>>> GetSocialMedia(int userId)
		{
			IQueryable<SocialMedium> query = _context.SocialMedia;
			query = query.Where(s => s.SocialMediaUserId == userId);

			List<SocialMedium> objects = await query.ToListAsync();
			List<GetSocialMedia> dtos = objects.Select(obj => SocialMediaMapper.AsDto(obj)).ToList();

			return dtos;
		}
	}
}
