using Personal_Web_API.Dtos;
using Personal_Web_API.Models;

namespace Personal_Web_API.Mappers
{
	public class ProjectMapper
	{
		public static GetProject AsDto(Project obj)
		{
			return new GetProject (
				obj.Id,
				obj.ProjectName,
				obj.ProjectDescription,
				obj.ProjectUrl,
				obj.ImageUrl
			);
		}

		public static Project AsObject(CreateProject dto)
		{
			return new Project
			{
				ProjectName = dto.ProjectName,
				ProjectDescription = dto.ProjectDescription,
				ProjectUrl = dto.ProjectUrl,
				ImageUrl = dto.ImageUrl,
				ProjectUserId = dto.ProjectUserId
			};
		}
	}
}
