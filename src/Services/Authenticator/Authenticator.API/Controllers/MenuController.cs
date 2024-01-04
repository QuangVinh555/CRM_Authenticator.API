using Authenticator.Application.Features.V1.Commands.Menu;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Authenticator.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        public MenuController() { }

        [HttpPost]
        public async Task<IActionResult> CreateMenu(CreateMenuCommand commamd)
        {
            return Ok();                                       
        }
    }
}
