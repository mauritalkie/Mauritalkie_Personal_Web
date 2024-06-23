﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Personal_Web_API.Dtos;
using Personal_Web_API.Mappers;
using Personal_Web_API.Models;
using Personal_Web_API.Services.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Personal_Web_API.Services.Implementations
{
	public class AboutMeService : IAboutMeService
	{
		private readonly PersonalWebDbContext _context;
		private readonly IUserService _userService;

		public AboutMeService(PersonalWebDbContext context, IUserService userService)
		{
			_context = context;
			_userService = userService;
		}

		public async Task<ActionResult<List<GetAboutMe>>> GetAboutMeOwner()
		{
			int userId = int.Parse(_userService.GetMyId());
			IQueryable<AboutMe> query = _context.AboutMes;
			query = query.Where(a => a.AboutMeUserId == userId);

			List<AboutMe> objects = await query.ToListAsync();
			List<GetAboutMe> dtos = objects.Select(obj => AboutMeMapper.AsDto(obj)).ToList();
			return dtos;
		}

		public async Task<ActionResult<List<GetAboutMe>>> GetAboutMeViewer()
		{
			List<AboutMe> objects = await _context.AboutMes.ToListAsync();
			List<GetAboutMe> dtos = objects.Select(obj => AboutMeMapper.AsDto(obj)).ToList();
			return dtos;
		}
	}
}
