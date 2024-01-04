using Core.Exceptions;
using Core.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Auth
{
    public interface ITokenService
    {
        Task<TokenResponse> GetToken(TokenRequest request);
    }
    public class TokenService : ITokenService
    {
        public Task<TokenResponse> GetToken(TokenRequest request)
        {

            throw new CommonException(CommonResource.MSG_FAIL, "Đăng nhập");
        }
    }
}
