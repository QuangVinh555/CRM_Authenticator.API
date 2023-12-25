using Infrastructure.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Authenticator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly CRMContext _context;

        public TestController(CRMContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Test() {
            var test = await _context.AccountModels.Select(x => new
            {
                FullName = x.FullName,
                CreateBy = x.CreateBy,
            }).ToListAsync();
            return Ok(test);
        }
    }
}
