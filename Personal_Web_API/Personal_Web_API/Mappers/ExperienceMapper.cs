using Personal_Web_API.Dtos;
using Personal_Web_API.Models;

namespace Personal_Web_API.Mappers
{
	public class ExperienceMapper
	{
		public static GetExperience AsDto(Experience obj)
		{
			return new GetExperience(obj.ExperienceDescription);
		}
	}
}
