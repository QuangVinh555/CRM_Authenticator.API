using Authenticator.Application.Features.V1.Commands.Menu;
using Core.Atrributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.WebSockets;

namespace Authenticator.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    //[Authorization]
    [ApiController]
    public class MenuController : ControllerBase
    {
        public MenuController() { }
        [HttpGet]
        public async Task<IActionResult> GetMenu()
        {
            List<string> menus = new List<string>{
                "A", "B", "C", "D","E", "G", "F","H"
            };
            List<string> functions = new List<string>{
                "A", "C", "D","E"
            };
            List<string> listRes = new List<string>();
            List<string> listMessage = new List<string>();
            foreach (var m in menus) {
                var a = functions.Where(x => x.Contains(m)).ToList();
                if(a.Any())
                {
                    listRes.AddRange(a);
                    listMessage.Add("true");
                }
                else
                {
                    listRes.Add(m);
                    listMessage.Add("false");

                }
            }
            listRes.AddRange(listMessage);

            return Ok(listRes);
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateMenu(CreateMenuCommand commamd)
        //{
        //    return Ok(123);                                       
        //}

        [HttpPost]
        public async Task<IActionResult> TestMenu2([FromQuery]CreateMenuCommand commamd)
        {
            return Ok(123);
        }
    }
}
