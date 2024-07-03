namespace Personal_Web_API.Dtos
{
	public record GetAboutMe (
		int Id,
		string AboutMeDescription
	);

	public class CreateAboutMe
	{
		public string AboutMeDescription { get; set; }
		public int AboutMeUserId { get; set; }
	}

	public record UpdateAboutMe (
		int Id,
		string AboutMeDescription
	);
}
