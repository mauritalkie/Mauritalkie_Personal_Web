using Microsoft.AspNetCore.Mvc;
using Personal_Web_API.Dtos;

namespace Personal_Web_API.Services.Interfaces
{
	public interface ISocialMediaService
	{
		public Task<ActionResult<List<GetSocialMedia>>> GetSocialMediaOwner();
		public Task<ActionResult<List<GetSocialMedia>>> GetSocialMediaViewer();
		public Task<ActionResult> CreateSocialMedia(CreateSocialMedia socialMediaDto);
		public Task<ActionResult> UpdateSocialMedia(UpdateSocialMedia socialMediaDto);
		public Task<ActionResult> DeleteSocialMedia(int id);
	}
}
