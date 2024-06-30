using Personal_Web_API.Dtos;
using Personal_Web_API.Models;

namespace Personal_Web_API.Mappers
{
	public class AboutMeMapper
	{
		public static GetAboutMe AsDto(AboutMe obj)
		{
			return new GetAboutMe (
				obj.Id,
				obj.AboutMeDescription
			);
		}

		public static AboutMe AsObject(CreateAboutMe dto)
		{
			return new AboutMe
			{
				AboutMeDescription = dto.AboutMeDescription,
				AboutMeUserId = dto.AboutMeUserId
			};
		}
	}
}
