using TaskList.Dto.Models;
using TaskList.Dto.Response;

namespace TaskList.Services
{
    public interface IUserApiService
    {
        public Result AddUser(UserDto user);
        public Result GetUser(string login);
        public Result UpdateUser(UserDto user);
        public Result DeleteUser(UserDto user);
    }
}
