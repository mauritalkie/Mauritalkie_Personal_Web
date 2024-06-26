﻿using Personal_Web_API.Dtos;
using Personal_Web_API.Models;

namespace Personal_Web_API.Mappers
{
	public class SocialMediaMapper
	{
		public static GetSocialMedia AsDto(SocialMedium obj)
		{
			return new GetSocialMedia (
				obj.SocialMediaName, 
				obj.SocialMediaUrl, 
				obj.ImageUrl
			);
		}
	}
}
