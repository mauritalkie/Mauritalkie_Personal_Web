using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Personal_Web_API.Dtos;
using Personal_Web_API.Mappers;
using Personal_Web_API.Models;
using Personal_Web_API.Services.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Personal_Web_API.Services.Implementations
{
	public class SocialMediaService : ISocialMediaService
	{
		private readonly PersonalWebDbContext _context;
		private readonly IUserService _userService;

		public SocialMediaService(PersonalWebDbContext context, IUserService userService)
		{
			_context = context;
			_userService = userService;
		}

		public async Task<ActionResult> CreateSocialMedia(CreateSocialMedia socialMediaDto)
		{
			socialMediaDto.SocialMediaUserId = int.Parse(_userService.GetMyId());
			SocialMedium socialMedium = SocialMediaMapper.AsObject(socialMediaDto);

			_context.SocialMedia.Add(socialMedium);
			await _context.SaveChangesAsync();

			return new JsonResult("Social media created successfully");
		}

		public async Task<ActionResult> DeleteSocialMedia(int id)
		{
			var dbSocialMedia = await _context.SocialMedia.FindAsync(id);
			if (dbSocialMedia == null) return new JsonResult("Social media not found");

			_context.SocialMedia.Remove(dbSocialMedia);
			await _context.SaveChangesAsync();

			return new JsonResult("Social media deleted successfully");
		}

		public async Task<ActionResult<List<GetSocialMedia>>> GetSocialMediaOwner()
		{
			int userId = int.Parse(_userService.GetMyId());
			IQueryable<SocialMedium> query = _context.SocialMedia;
			query = query.Where(s => s.SocialMediaUserId == userId);

			List<SocialMedium> objects = await query.ToListAsync();
			List<GetSocialMedia> dtos = objects.Select(obj => SocialMediaMapper.AsDto(obj)).ToList();
			return dtos;
		}

		public async Task<ActionResult<List<GetSocialMedia>>> GetSocialMediaViewer()
		{
			List<SocialMedium> objects = await _context.SocialMedia.ToListAsync();
			List<GetSocialMedia> dtos = objects.Select(obj => SocialMediaMapper.AsDto(obj)).ToList();
			return dtos;
		}

		public async Task<ActionResult> UpdateSocialMedia(UpdateSocialMedia socialMediaDto)
		{
			var dbSocialMedia = await _context.SocialMedia.FindAsync(socialMediaDto.Id);
			if (dbSocialMedia == null) return new JsonResult("Social media not found");

			dbSocialMedia.SocialMediaName = socialMediaDto.SocialMediaName;
			dbSocialMedia.SocialMediaUrl = socialMediaDto.SocialMediaUrl;
			dbSocialMedia.UpdatedAt = DateTime.Now;

			await _context.SaveChangesAsync();
			return new JsonResult("Social media updated successfully");
		}
	}
}
