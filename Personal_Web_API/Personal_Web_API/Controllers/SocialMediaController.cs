using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Personal_Web_API.Dtos;
using Personal_Web_API.Services.Interfaces;

namespace Personal_Web_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SocialMediaController : ControllerBase
	{
		private readonly ISocialMediaService _socialMediaService;

		public SocialMediaController(ISocialMediaService socialMediaService)
		{
			_socialMediaService = socialMediaService;
		}

		[HttpGet("{userId}")]
		public async Task<ActionResult<List<GetSocialMedia>>> GetSocialMedia(int userId)
		{
			return await _socialMediaService.GetSocialMedia(userId);
		}
	}
}
