using System;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Sampekey.Contex
{
    public interface ISampeKeyAccount
    {
        
        Task<IdentityResult> CreateAccount(SampekeyUserAccountRequest model);
        Task<SignInResult> LoginAccount(SampekeyUserAccountRequest model);
        Task<IdentityResult> ForceChangePassword(SampekeyUserAccountRequest model);
        Task<IdentityResult> UpdatePassword(SampekeyUserAccountRequest model);
        string CreateToken(SampekeyUserAccountRequest model);

    } 
}