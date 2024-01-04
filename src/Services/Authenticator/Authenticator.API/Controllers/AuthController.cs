using Core.Auth;
using Core.Commons;
using Core.Properties;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Authenticator.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public AuthController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] TokenRequest request)
        {
            var res = await _tokenService.GetToken(request);
            return Ok(new ApiSuccessResponse<TokenResponse>
            {
                IsSuccess = true,
                Message = string.Format(CommonResource.MSG_SUCSSESS, "Đăng nhập"),
                Data = res
            }); 
        }
    }
}
