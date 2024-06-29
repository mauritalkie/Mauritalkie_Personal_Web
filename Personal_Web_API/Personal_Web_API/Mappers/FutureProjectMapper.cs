using Personal_Web_API.Dtos;
using Personal_Web_API.Models;

namespace Personal_Web_API.Mappers
{
	public class FutureProjectMapper
	{
		public static GetFutureProject AsDto(FutureProject obj)
		{
			return new GetFutureProject(obj.ProjectDescription);
		}
	}
}
