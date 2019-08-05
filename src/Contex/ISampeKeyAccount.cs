using System;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace Sampekey.Contex
{
    public interface ISampeKeyAccount
    {
        
        string CreateToken(SampekeyUserAccountRequest model);
        TokenValidationParameters GetTokenValidationParameters();

    } 
}