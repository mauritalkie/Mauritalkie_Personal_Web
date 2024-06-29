using Microsoft.AspNetCore.Authorization;
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

		[HttpGet("Owner/GetSocialMedia"), Authorize]
		public async Task<ActionResult<List<GetSocialMedia>>> GetSocialMediaOwner()
		{
			return await _socialMediaService.GetSocialMediaOwner();
		}

		[HttpGet("Viewer/GetSocialMedia")]
		public async Task<ActionResult<List<GetSocialMedia>>> GetSocialMediaViewer()
		{
			return await _socialMediaService.GetSocialMediaViewer();
		}

		[HttpPost, Authorize]
		public async Task<ActionResult> CreateSocialMedia(CreateSocialMedia socialMediaDto)
		{
			return await _socialMediaService.CreateSocialMedia(socialMediaDto);
		}

		[HttpPut, Authorize]
		public async Task<ActionResult> UpdateSocialMedia(UpdateSocialMedia socialMediaDto)
		{
			return await _socialMediaService.UpdateSocialMedia(socialMediaDto);
		}

		[HttpDelete("{id}"), Authorize]
		public async Task<ActionResult> DeleteSocialMedia(int id)
		{
			return await _socialMediaService.DeleteSocialMedia(id);
		}
	}
}
