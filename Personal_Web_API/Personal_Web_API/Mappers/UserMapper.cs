using Personal_Web_API.Dtos;
using Personal_Web_API.Models;

namespace Personal_Web_API.Mappers
{
	public class UserMapper
	{
		public static User AsObject(CreateUser dto)
		{
			return new User
			{
				Username = dto.Username,
				UserHashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.UserPassword),
				UserPictureUrl = dto.UserPictureUrl
			};
		}

		public static GetUser AsDto(User obj)
		{
			return new GetUser (
				obj.Username,
				obj.UserPictureUrl
			);
		}
	}
}
