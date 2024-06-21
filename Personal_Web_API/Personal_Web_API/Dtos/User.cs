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

	public class LoginUser
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string UserPassword { get; set; }
	}

	public record SessionUser (
		string Token	
	);
}
