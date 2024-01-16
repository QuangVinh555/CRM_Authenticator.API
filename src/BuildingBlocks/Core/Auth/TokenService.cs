using Core.Exceptions;
using Core.Properties;
using Infrastructure.Entites;
using Microsoft.EntityFrameworkCore;
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
        private readonly CRMContext _context;

        public TokenService(CRMContext context) {
            _context = context;
        }
        public async Task<TokenResponse> GetToken(TokenRequest request)
        {
            var user = _context.AccountModels.AsQueryable();
            var a = user.Count();
            if (user == null) { throw new CommonException(CommonResource.MSG_FAIL, "Dang nhap"); }
            return null;
        }
    }
}
