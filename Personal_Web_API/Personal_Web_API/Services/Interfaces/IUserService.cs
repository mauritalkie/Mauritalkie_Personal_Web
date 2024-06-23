using Microsoft.AspNetCore.Mvc;
using Personal_Web_API.Dtos;

namespace Personal_Web_API.Services.Interfaces
{
	public interface IUserService
	{
		public Task<ActionResult<List<DisplayUserInfo>>> DisplayUserInfo(int userId);
		public Task<ActionResult> CreateUser(CreateUser userDto);
		public Task<ActionResult<string>> Login(LoginUser userDto);
		public string GetMyName();
		public string GetMyId();
	}
}
