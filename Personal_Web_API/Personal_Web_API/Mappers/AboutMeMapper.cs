using Personal_Web_API.Dtos;
using Personal_Web_API.Models;

namespace Personal_Web_API.Mappers
{
	public class AboutMeMapper
	{
		public static GetAboutMe AsDto(AboutMe obj)
		{
			return new GetAboutMe(obj.AboutMeDescription);
		}
	}
}
