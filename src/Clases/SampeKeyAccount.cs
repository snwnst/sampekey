
using Sampekey.Contex;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

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

    }
}