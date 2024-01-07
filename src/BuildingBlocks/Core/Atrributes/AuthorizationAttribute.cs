using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Core.Atrributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]

    public class AuthorizationAttribute : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var userIdentity = context.HttpContext.User?.Identity;
            var userName = userIdentity?.Name;


            if (string.IsNullOrEmpty(userName))
            {
                // not logged in
                context.Result = new JsonResult(new { code = 401, message = "Vui lòng đăng nhập." }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}
