﻿using Personal_Web_API.Dtos;
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
				obj.ProjectUrl,
				obj.ImageUrl
			);
		}

		public static Project AsObject(CreateProject dto)
		{
			return new Project
			{
				ProjectName = dto.ProjectName,
				ProjectUrl = dto.ProjectUrl,
				ImageUrl = dto.ImageUrl
			};
		}
	}
}
