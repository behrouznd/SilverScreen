using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Service.Contracts.Base;
using Shared.DataTransferObjects.Users;

namespace Presentation.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public AuthenticationController(IServiceManager serviceManager)
        {
            this._serviceManager = serviceManager;
        }


        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterUser([FromBody]UserForRegisterationDto userForRegisterationDto)
        {            
            var result = await _serviceManager.authenticationService.RegisterUser(userForRegisterationDto);
            if(!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            return StatusCode(201);
        }

        [HttpPost("login")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate([FromBody]UserForAuthenticationDto userForAuth)
        {
            if(! await _serviceManager.authenticationService.ValidateUser(userForAuth))
                return Unauthorized();

            var tokenDto = await _serviceManager.authenticationService.CreateToken(populateExp: true);

            return Ok(tokenDto);

        }
    }
}
