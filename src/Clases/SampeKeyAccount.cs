using System;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Sampekey.Contex;
using Sampekey.Model;

namespace Sampekey.Clases
{
    public class SampeKeyAccount : ISampeKeyAccount
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly SampekeyDbContex dbcontex;
        private readonly string key;
        public SampeKeyAccount(
            SampekeyDbContex _dbcontex,
            UserManager<User> _userManager,
            SignInManager<User> _signInManager
        )
        {
            this.dbcontex = _dbcontex;
            this.userManager = _userManager;
            this.signInManager = _signInManager;
            this.key = Environment.GetEnvironmentVariable("SAMPEKEY_SECRET_KEY");
        }

        public string CreateToken(SampekeyUserAccountRequest model)
        {
            return new JwtSecurityTokenHandler().WriteToken(GetJwtSecurityToken(model));
        }

        public TokenValidationParameters GetTokenValidationParameters()
        {
            return new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                ClockSkew = TimeSpan.Zero
            };
        }

        private JwtSecurityToken GetJwtSecurityToken(SampekeyUserAccountRequest model)
        {
            return new JwtSecurityToken(
               issuer: model.Issuer,
               audience: model.Audience,
               notBefore: DateTime.UtcNow,
               expires: DateTime.UtcNow.AddHours(model.ExpirationHours),
               claims: new[]{
                new Claim(JwtRegisteredClaimNames.UniqueName, model.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
               },
               signingCredentials: new SigningCredentials(
                   new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                   SecurityAlgorithms.HmacSha256
                )
            );
        }

    }
}