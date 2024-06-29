using Microsoft.AspNetCore.Mvc;
using Personal_Web_API.Dtos;

namespace Personal_Web_API.Services.Interfaces
{
	public interface IUserService
	{
		public Task<ActionResult<List<DisplayUserInfo>>> DisplayUserInfoViewer(int userId);
		public Task<ActionResult<List<DisplayUserInfo>>> DisplayUserInfoOwner();
		public Task<ActionResult> CreateUser(CreateUser userDto);
		public Task<ActionResult<SessionUser>> Login(LoginUser userDto);
		public Task<ActionResult> UpdateUser(UpdateUser userDto);
		public Task<ActionResult<GetUser>> GetCurrentUser();
		public string GetMyName();
		public string GetMyId();
	}
}
