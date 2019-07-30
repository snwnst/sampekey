using System;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Sampekey.Contex;

namespace Sampekey.Clases
{
    public class SampeKeyAccount : ISampeKeyAccount
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly SampekeyDbContex dbcontex;
        public SampeKeyAccount(
            SampekeyDbContex _dbcontex,
            UserManager<IdentityUser> _userManager,
            SignInManager<IdentityUser> _signInManager
        )
        {
            this.dbcontex = _dbcontex;
            this.userManager = _userManager;
            this.signInManager = _signInManager;
        }

        public async Task<IdentityResult> CreateAccount(SampekeyUserAccountRequest model)
        {
            return await this.userManager.CreateAsync(model, model.Password);
        }

        public async Task<SignInResult> LoginAccount(SampekeyUserAccountRequest model)
        {
            return await this.signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: false, lockoutOnFailure: false);
        }

        public string CreateToken(SampekeyUserAccountRequest model)
        {
            return new JwtSecurityTokenHandler().WriteToken(GetJwtSecurityToken(model));
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
                   new SymmetricSecurityKey(
                       Encoding.UTF8.GetBytes(
                           Environment.GetEnvironmentVariable("SAMPEKEY_SECRET_KEY")
                        )
                    ),
                   SecurityAlgorithms.HmacSha256
                )
            );
        }

    }
}