using Domain;
using TaskList.Dto.Models;

namespace TaskList.Converters
{
    public static class UserToDtoConverter
    {
        public static Domain.User StringToUser(this string userName)
        {
            return new Domain.User()
            {
                FullName = userName
            };
        }

        public static string UserToString(this Domain.User user)
        {
            if (user == null)
                return "";
            return user.FullName;
        }

        public static Domain.User UserDtoToUser(this UserDto dto)
        {
            return new Domain.User()
            {
                FullName = dto.FullName,
                Login = dto.Login,
                Password = dto.Password,
                Role = (UserRole)dto.Role
            };
        }

        public static UserDto UserToUserDto(this Domain.User user) 
        {
            return new UserDto()
            {
                FullName = user.FullName,
                Login = user.Login,
                Password = user.Password,
                Role = (int)user.Role
            };
        }
    }
}
