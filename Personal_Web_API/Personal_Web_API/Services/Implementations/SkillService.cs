using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Personal_Web_API.Dtos;
using Personal_Web_API.Mappers;
using Personal_Web_API.Models;
using Personal_Web_API.Services.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Personal_Web_API.Services.Implementations
{
	public class SkillService : ISkillService
	{
		private readonly PersonalWebDbContext _context;
		private readonly IUserService _userService;

		public SkillService(PersonalWebDbContext context, IUserService userService)
		{
			_context = context;
			_userService = userService;
		}

		public async Task<ActionResult<List<GetSkill>>> GetSkillsOwner()
		{
			int userId = int.Parse(_userService.GetMyId());
			IQueryable<Skill> query = _context.Skills;
			query = query.Where(s => s.SkillUserId == userId);

			List<Skill> objects = await query.ToListAsync();
			List<GetSkill> dtos = objects.Select(obj => SkillMapper.AsDto(obj)).ToList();
			return dtos;
		}

		public async Task<ActionResult<List<GetSkill>>> GetSkillsViewer()
		{
			List<Skill> objects = await _context.Skills.ToListAsync();
			List<GetSkill> dtos = objects.Select(obj => SkillMapper.AsDto(obj)).ToList();
			return dtos;
		}
	}
}
