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
        public SampeKeyAccount(
            SampekeyDbContex _dbcontex,
            UserManager<User> _userManager,
            SignInManager<User> _signInManager
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
            var result = await dbcontex.User.FirstOrDefaultAsync(usr => usr.UserName == model.UserName);
            return await this.signInManager.PasswordSignInAsync(result.Email, model.Password, isPersistent: false, lockoutOnFailure: false);
        }

        public async Task<IdentityResult> UpdatePassword(SampekeyUserAccountRequest model)
        {        
            return await userManager.ChangePasswordAsync(
                await userManager.FindByEmailAsync(model.Email),
                model.Password,
                model.NewPassword
            );
        }

        public async Task<IdentityResult> ForceChangePassword(SampekeyUserAccountRequest model)
        {
            var currentUser = await userManager.FindByEmailAsync(model.Email);
            await userManager.RemovePasswordAsync(currentUser);
            return await userManager.AddPasswordAsync(currentUser, model.Password);
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