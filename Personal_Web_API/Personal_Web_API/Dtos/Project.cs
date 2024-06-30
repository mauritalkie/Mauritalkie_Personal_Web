namespace Personal_Web_API.Dtos
{
	public record GetProject (
		int Id,
		string ProjectName,
		string ProjectDescription,
		string ProjectUrl,
		string ImageUrl
	);

	public class CreateProject
	{
		public string ProjectName { get; set; }
		public string ProjectDescription { get; set; }
		public string ProjectUrl { get; set; }
		public string ImageUrl { get; set; }
		public int ProjectUserId { get; set; }
	}

	public record UpdateProject (
		int Id,
		string ProjectName,
		string ProjectDescription,
		string ProjectUrl,
		string ImageUrl
	);
}
