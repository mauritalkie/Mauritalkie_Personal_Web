using Personal_Web_API.Dtos;
using Personal_Web_API.Models;

namespace Personal_Web_API.Mappers
{
	public class SkillMapper
	{
		public static GetSkill AsDto(Skill obj)
		{
			return new GetSkill(obj.SkillDescription);
		}
	}
}
