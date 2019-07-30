using System;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Sampekey.Contex
{
    public interface ISampeKeyAccount
    {
        
        Task<IdentityResult> CreateAccount(SampekeyUserAccountRequest model);
        Task<SignInResult> LoginAccount(SampekeyUserAccountRequest model);
        string CreateToken(SampekeyUserAccountRequest model);
    } 
}