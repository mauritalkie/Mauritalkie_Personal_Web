using Azure.Identity;

namespace Personal_Web_API.Dtos
{
	public class DisplayUserInfo
	{
		public string Username { get; set; }
		public string UserPictureUrl { get; set; }
		public string AboutMeDescription { get; set; }
	}

	public record CreateUser (
		string Username,
		string UserPassword,
		string UserPictureUrl
	);

	public record LoginUser (
		int Id,
		string Username,
		string UserPassword
	);
}
