using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Service.Contracts.Base;
using Shared.DataTransferObjects.Users;

namespace Presentation.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public TokenController(IServiceManager serviceManager)
        {
            this._serviceManager = serviceManager;
        }

        [HttpPost("refresh")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Refresh([FromBody] TokenDto tokenDto)
        {
            var tokenDtoToReturn = await _serviceManager.authenticationService.RefreshToken(tokenDto);
            return Ok(tokenDtoToReturn);
        }
    }
}
