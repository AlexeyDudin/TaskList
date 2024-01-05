using Application;
using Domain;
using TaskList.Converters;
using TaskList.Dto.Models;
using TaskList.Dto.Response;

namespace TaskList.Services
{
    public class UserApiService : IUserApiService
    {
        private readonly IUserService _userService;
        public UserApiService(IUserService userService) 
        {
            _userService = userService;
        }

        public Result AddUser(UserDto user)
        {
            try
            {
                return new Result(_userService.AddUser(user.UserDtoToUser()), ResponseStatus.Ok);
            }
            catch (Exception ex) 
            {
                return new Result(ex.Message, ResponseStatus.Error);
            }
        }

        public Result DeleteUser(UserDto user)
        {
            try
            {
                return new Result(_userService.DeleteUser(user.UserDtoToUser()), ResponseStatus.Ok);
            }
            catch (Exception ex)
            {
                return new Result(ex.Message, ResponseStatus.UserNotFound);
            }
        }

        public Result GetUser(UserDto user)
        {
            try
            {
                return new Result(_userService.GetUserInfo(user.login, user.password), ResponseStatus.Ok);
            }
            catch (Exception ex)
            {
                return new Result(ex.Message, ResponseStatus.Error);
            }
        }

        public Result UpdateUser(UserDto user)
        {
            try
            {
                return new Result(_userService.UpdateUser(user.UserDtoToUser()), ResponseStatus.Ok);
            }
            catch (Exception ex)
            {
                return new Result(ex.Message, ResponseStatus.Error);
            }
        }
    }
}
