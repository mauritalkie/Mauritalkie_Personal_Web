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

		public async Task<ActionResult<List<DisplayUserInfo>>> DisplayUserInfo(int userId)
		{
			return await _context.DisplayUsers.FromSqlInterpolated($"EXEC sp_display_user_info {userId}").ToListAsync();
		}

		public async Task<ActionResult<string>> Login(LoginUser userDto)
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

			string token = CreateToken(userDto);

			return token;
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
	}
}
