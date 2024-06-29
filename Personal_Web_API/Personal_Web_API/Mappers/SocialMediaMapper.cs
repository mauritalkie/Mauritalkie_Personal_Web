using Personal_Web_API.Dtos;
using Personal_Web_API.Models;

namespace Personal_Web_API.Mappers
{
	public class SocialMediaMapper
	{
		public static GetSocialMedia AsDto(SocialMedium obj)
		{
			return new GetSocialMedia (
				obj.Id,
				obj.SocialMediaName, 
				obj.SocialMediaUrl
			);
		}

		public static SocialMedium AsObject(CreateSocialMedia obj)
		{
			return new SocialMedium
			{
				SocialMediaName = obj.SocialMediaName,
				SocialMediaUrl = obj.SocialMediaUrl,
				SocialMediaUserId = obj.SocialMediaUserId
			};
		}
	}
}
