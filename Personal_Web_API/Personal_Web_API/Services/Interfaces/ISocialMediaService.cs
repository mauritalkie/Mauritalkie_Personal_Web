using Microsoft.AspNetCore.Mvc;
using Personal_Web_API.Dtos;

namespace Personal_Web_API.Services.Interfaces
{
	public interface ISocialMediaService
	{
		public Task<ActionResult<List<GetSocialMedia>>> GetSocialMedia(int userId);
	}
}
