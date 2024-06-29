using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Personal_Web_API.Dtos;
using Personal_Web_API.Mappers;
using Personal_Web_API.Models;
using Personal_Web_API.Services.Interfaces;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Personal_Web_API.Services.Implementations
{
	public class UserService : IUserService
	{
		private readonly PersonalWebDbContext _context;
		private readonly IConfiguration _configuration;
		private readonly IHttpContextAccessor _contextAccessor;

		public UserService(PersonalWebDbContext context, IConfiguration configuration, IHttpContextAccessor contextAccessor)
		{
			_context = context;
			_configuration = configuration;
			_contextAccessor = contextAccessor;
		}

		private string CreateToken(LoginUser userDto)
		{
			List<Claim> claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, userDto.Username),
				new Claim(ClaimTypes.NameIdentifier, userDto.Id.ToString()),
				new Claim(ClaimTypes.Role, "Admin"),
				new Claim(ClaimTypes.Role, "User")
			};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
				_configuration.GetSection("Authentication:Schemes:Bearer:SigningKeys:0:Value").Value!));

			var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

			var token = new JwtSecurityToken(
					claims: claims,
					expires: DateTime.Now.AddDays(1),
					signingCredentials: credentials
				);

			var jwt = new JwtSecurityTokenHandler().WriteToken(token);

			return jwt;
		}

		public async Task<ActionResult> CreateUser(CreateUser userDto)
		{
			User user = UserMapper.AsObject(userDto);

			_context.Users.Add(user);
			await _context.SaveChangesAsync();

			return new JsonResult("User created successfully");
		}

		public async Task<ActionResult<List<DisplayUserInfo>>> DisplayUserInfoViewer(int userId)
		{
			return await _context.DisplayUsers.FromSqlInterpolated($"EXEC sp_display_user_info {userId}").ToListAsync();
		}

		public async Task<ActionResult<List<DisplayUserInfo>>> DisplayUserInfoOwner()
		{
			int userId = int.Parse(GetMyId());
			return await _context.DisplayUsers.FromSqlInterpolated($"EXEC sp_display_user_info {userId}").ToListAsync();
		}

		public async Task<ActionResult<SessionUser>> Login(LoginUser userDto)
		{
			var dbUser = await _context.Users.Where(entity => entity.Username == userDto.Username).FirstOrDefaultAsync();

			if (dbUser == null)
			{
				return new JsonResult("User not found");
			} 

			if(!BCrypt.Net.BCrypt.Verify(userDto.UserPassword, dbUser.UserHashedPassword))
			{
				return new JsonResult("Wrong password");
			}

			userDto.Id = dbUser.Id;

			SessionUser sessionUser = new SessionUser(CreateToken(userDto));

			return sessionUser;
		}

		public string GetMyName()
		{
			var result = string.Empty;
			if(_contextAccessor.HttpContext is not null)
			{
				result = _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
			}
			return result;
		}

		public string GetMyId()
		{
			var result = string.Empty;
			if(_contextAccessor.HttpContext is not null)
			{
				result = _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
			}
			return result;
		}

		public async Task<ActionResult> UpdateUser(UpdateUser userDto)
		{
			int userId = int.Parse(GetMyId());
			var dbUser = await _context.Users.FindAsync(userId);
			if (dbUser == null) return new JsonResult("User not found");

			dbUser.Username = userDto.Username;
			dbUser.UserPictureUrl = userDto.UserPictureUrl;
			dbUser.UpdatedAt = DateTime.Now;

			if (userDto.UserPassword != string.Empty)
				dbUser.UserHashedPassword = BCrypt.Net.BCrypt.HashPassword(userDto.UserPassword);

			await _context.SaveChangesAsync();
			return new JsonResult("User updated successfully");
		}

		public async Task<ActionResult<GetUser>> GetCurrentUser()
		{
			int userId = int.Parse(GetMyId());
			var dbUser = await _context.Users.FindAsync(userId);

			if (dbUser == null) return new JsonResult("User not found");

			return UserMapper.AsDto(dbUser);
		}
	}
}
