using Microsoft.AspNetCore.Mvc;
using Personal_Web_API.Dtos;

namespace Personal_Web_API.Services.Interfaces
{
	public interface IAboutMeService
	{
		public Task<ActionResult<List<GetAboutMe>>> GetAboutMeOwner();
		public Task<ActionResult<List<GetAboutMe>>> GetAboutMeViewer();
	}
}
