using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Auth
{
    public class TokenResponse
    {
        public Guid? AccountId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpriedTimeAccessToken { get; set; }
        public DateTime ExpriedTimeRefreshToken { get; set; }
    }

    public class TokenRoleResponse
    {
        public Guid? RoleId { get; set; }
        public string RoleCode { get; set; }
        public string RoleName { get; set; }
    }

    public class TokenRolePageFunctionResponse
    {

    }
}
