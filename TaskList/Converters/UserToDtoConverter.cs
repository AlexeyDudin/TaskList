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
                FullName = dto.fullName,
                Login = dto.login,
                Password = dto.password,
                Role = (UserRole)dto.role
            };
        }

        public static UserDto UserToUserDto(this Domain.User user) 
        {
            return new UserDto()
            {
                fullName = user.FullName,
                login = user.Login,
                password = user.Password,
                role = (int)user.Role
            };
        }
    }
}
