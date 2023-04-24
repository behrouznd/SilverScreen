using Microsoft.AspNetCore.Identity;
using Shared.DataTransferObjects.Users;

namespace Service.Contracts.Users
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserForRegisterationDto userForRegisterationDto);
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
        Task<TokenDto> CreateToken(bool populateExp);
        Task<TokenDto> RefreshToken(TokenDto tokenDto);
    }
}
