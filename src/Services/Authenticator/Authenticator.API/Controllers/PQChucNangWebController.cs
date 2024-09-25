using Authenticator.Application.Features.V1.Commands.PQChucNangWeb;
using Core.Atrributes;
using Core.Commons;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Authenticator.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    //[Authorization]
    [ApiController]
    public class PQChucNangWebController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PQChucNangWebController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Phân quyền chức năng web
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("create-pqchucnangweb")]
        public async Task<IActionResult> CreatePQChucNangWeb(CreatePQChucNangWebCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(new ApiSuccessResponse<bool>
            {
                Data = result,
            });
        }
    }
}
