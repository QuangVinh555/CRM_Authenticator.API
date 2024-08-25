using Core.Configurations;
using Core.Exceptions;
using Core.Extensions;
using Core.Properties;
using Core.Services.Common;
using Infrastructure.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
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
        private readonly JwtSettings _jwtSettings;
        private readonly CRMContext _context;
        private readonly ICommonService _service;

        public TokenService(JwtSettings jwtSettings, CRMContext context, ICommonService service ) {
            _jwtSettings = jwtSettings;
            _context = context;
            _service = service;
        }
        public async Task<TokenResponse> GetToken(TokenRequest request)
        {
            // Nếu có nhập mật khẩu thì mã hóa
            if (!string.IsNullOrEmpty(request.Password))
            {
                request.Password = _service.GetMd5Sum(request.Password);
            }

            // Kiểm tra tài khoản đăng nhập
            var account = await _context.AccountModels.FirstOrDefaultAsync(x => x.UserName == request.UserName 
                    && x.Password == request.Password);
            if (account == null) throw new CommonException(CommonResource.MSG_NOTFOUND, "Tài khoản hoặc mật khẩu");

            var token = new TokenResponse();

            token.UserName = request.UserName;
            token.FullName = account.FullName;

            var jwtToken = GenerateJwt(GetSigningCredentials(),token);
            token.AccessToken = jwtToken;
            if (token.UserName != null)
            {
                var refresh = GenRefreshToken(token.UserName);
                token.RefreshToken = refresh.Token;
            }
            return token;
           
        }
        private string GenerateJwt(SigningCredentials signingCredentials, TokenResponse account)
        {
            var ExpiredTime = new ConfigManager().ExpiredToken;
            var claims = new[]
            {
                    new Claim("Id", account.AccountId.ToString()),
                    new Claim(ClaimTypes.Name, account.UserName),
                    new Claim(ClaimTypes.Expiration, DateTime.Now.AddSeconds(Int64.Parse(ExpiredTime)).ToString("MMM ddd dd yyyy HH:mm:ss tt")),
                    new Claim(ClaimTypes.Sid, account.AccountId.ToString()),
                    new Claim(ClaimTypes.Upn, account.FullName??""),
                    //RoleCode
                    //new Claim(ClaimTypes.Role, account.Role ??""),
                    ////RoleName
                    //new Claim("RoleName",account.RoleName ?? ""),
                    ////SaleOrg Code
                    //new Claim ("SaleOrgCode", account.SaleOrgCode ?? ""),
                    ////Employee Code
                    //new Claim("EmployeeCode",account.EmployeeCode??""),
                    ////Company code
                    //new Claim("CompanyCode",account.CompanyCode ?? ""),
             };

            var expireTime = DateTime.Now.AddSeconds(Int64.Parse(ExpiredTime));

            var key = Encoding.ASCII.GetBytes(_jwtSettings.IssuerSigningKey);
            var token = new JwtSecurityToken(issuer: _jwtSettings.ValidIssuer,
                                              audience: _jwtSettings.ValidAudience,
                                              claims: claims,
                                              notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                                              expires: new DateTimeOffset(expireTime).DateTime,
                                              signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256));

            var tokenHandler = new JwtSecurityTokenHandler();   
            return tokenHandler.WriteToken(token);
        }


        private SigningCredentials GetSigningCredentials()
        {
            byte[] secret = Encoding.UTF8.GetBytes(_jwtSettings.IssuerSigningKey);
            return new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256);
        }

        private RefreshTokenResponse GenRefreshToken(string UserName)
        {
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                var randomBytes = new byte[64];
                rngCryptoServiceProvider.GetBytes(randomBytes);
                return new RefreshTokenResponse
                {
                    Token = Convert.ToBase64String(randomBytes),
                    Expires = DateTime.Now.AddMonths(1),
                    Created = DateTime.Now,
                    CreatedByUserName = UserName
                };
            }
        }
    }
}
