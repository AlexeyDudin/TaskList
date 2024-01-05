using Application;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskList.Dto.Models;

namespace WebAPI.Security.Auths
{
    public class TokenService : ITokenService
    {
        private readonly IUserService _userService;

        public TokenService( IUserService userService )
        {
            _userService = userService;
        }

        public string GenerateToken( UserDto userLoginDto )
        {
            if ( userLoginDto == null )
            {
                return string.Empty;
            }

            Domain.User user = _userService.GetUserInfo( userLoginDto.login, userLoginDto.password );

            if ( user == null )
            {
                return string.Empty;
            }

            List<Claim> authClaims = new()
            {
                new( ClaimTypes.UserName, user.FullName),
                new( ClaimTypes.Login, user.Login ),
                new( JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString() ),
                new( ClaimTypes.Role, UserRole.User )
            };

            JwtSecurityToken token = GetToken( authClaims );
            return new JwtSecurityTokenHandler().WriteToken( token );
        }

        private JwtSecurityToken GetToken( List<Claim> authClaims )
        {
            SymmetricSecurityKey authSigningKey = new( Encoding.UTF8.GetBytes( AuthOptions.KEY ) );
            JwtSecurityToken token = new(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                expires: DateTime.Now.AddHours( 3 ),
                claims: authClaims,
                signingCredentials: new( authSigningKey, SecurityAlgorithms.HmacSha256 ) );

            return token;
        }
    }
}
