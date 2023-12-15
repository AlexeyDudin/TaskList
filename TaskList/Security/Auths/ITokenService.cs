using TaskList.Dto.Models;

namespace WebAPI.Security.Auths
{
    public interface ITokenService
    {
        string GenerateToken( UserDto userLoginDto );
    }
}
