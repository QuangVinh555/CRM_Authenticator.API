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

        public List<TokenRoleResponse> RoleList { get; set; } = new();
        public TokenRolePageFunctionResponse AuthenticateList { get; set; } = new();
    }

    public class TokenRoleResponse
    {
        public Guid? RoleId { get; set; }
        public string RoleCode { get; set; }
        public string RoleName { get; set; }
    }

    public class TokenRolePageFunctionResponse
    {
        public string RoleCode { get; set; }
        public string RoleName { get; set; }
        public List<PageResponse> PageList { get; set; } = new();
    }

    public class PageResponse
    {
        public Guid? PageId { get; set; }
        public string PageName { get; set; }
        public List<FunctionResponse> FunctionList { get; set; } = new();
    }
    public class FunctionResponse
    {
        public Guid? FunctionId { get; set; }
        public string FunctionName { get; set; }
    }
}
