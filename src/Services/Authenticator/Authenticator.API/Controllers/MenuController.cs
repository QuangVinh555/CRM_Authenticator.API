using Authenticator.Application.Features.V1.Commands.Menu;
using Core.Atrributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Authenticator.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Authorization]
    [ApiController]
    public class MenuController : ControllerBase
    {
        public MenuController() { }
        [HttpGet]
        public async Task<IActionResult> GetMenu()
        {
            return Ok(123);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenu(CreateMenuCommand commamd)
        {
            return Ok(123);                                       
        }
    }
}
