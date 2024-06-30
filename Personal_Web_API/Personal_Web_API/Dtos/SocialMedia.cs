namespace Personal_Web_API.Dtos
{
	public record GetSocialMedia (
		int Id,
		string SocialMediaName,
		string SocialMediaUrl
	);

	public class CreateSocialMedia
	{
		public string SocialMediaName { get; set; }
		public string SocialMediaUrl { get; set; }
		public int SocialMediaUserId { get; set; }
	}

	public record UpdateSocialMedia (
		int Id,
		string SocialMediaName,
		string SocialMediaUrl
	);
}
