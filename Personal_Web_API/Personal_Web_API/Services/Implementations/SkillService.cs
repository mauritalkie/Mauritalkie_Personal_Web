using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Personal_Web_API.Dtos;
using Personal_Web_API.Mappers;
using Personal_Web_API.Models;
using Personal_Web_API.Services.Interfaces;

namespace Personal_Web_API.Services.Implementations
{
	public class SkillService : ISkillService
	{
		private readonly PersonalWebDbContext _context;

		public SkillService(PersonalWebDbContext context)
		{
			_context = context;
		}

		public async Task<ActionResult<List<GetSkill>>> GetSkills(int userId)
		{
			IQueryable<Skill> query = _context.Skills;
			query = query.Where(s => s.SkillUserId == userId);

			List<Skill> objects = await query.ToListAsync();
			List<GetSkill> dtos = objects.Select(obj => SkillMapper.AsDto(obj)).ToList();

			return dtos;
		}
	}
}
