using Microsoft.AspNetCore.Mvc;
using Personal_Web_API.Dtos;

namespace Personal_Web_API.Services.Interfaces
{
	public interface IUserService
	{
		public Task<ActionResult<List<DisplayUserInfo>>> DisplayUserInfo(int userId);
	}
}
