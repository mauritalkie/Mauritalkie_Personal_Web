﻿namespace Personal_Web_API.Dtos
{
	public record GetProject (
		int Id,
		string ProjectName,
		string ProjectDescription,
		string ProjectUrl,
		string ImageUrl
	);

	public record CreateProject (
		string ProjectName,
		string ProjectDescription,
		string ProjectUrl,
		string ImageUrl
	);

	public record UpdateProject (
		int Id,
		string ProjectName,
		string ProjectDescription,
		string ProjectUrl,
		string ImageUrl
	);
}
