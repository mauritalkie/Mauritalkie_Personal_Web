using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Personal_Web_API.Dtos;
using Personal_Web_API.Models;
using Personal_Web_API.Services.Interfaces;
using System.Collections.Generic;

namespace Personal_Web_API.Services.Implementations
{
	public class UserService : IUserService
	{
		private readonly PersonalWebDbContext _context;

		public UserService(PersonalWebDbContext context)
		{
			_context = context;
		}

		[HttpGet("DisplayInfo/{userId}")]
		public async Task<ActionResult<List<DisplayUserInfo>>> DisplayUserInfo(int userId)
		{
			return await _context.DisplayUsers.FromSqlInterpolated($"EXEC sp_display_user_info {userId}").ToListAsync();
		}
	}
}
