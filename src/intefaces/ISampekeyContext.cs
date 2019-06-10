using System;
using Microsoft.IdentityModel.Tokens;

namespace sampekey.interfaces
{
    public interface ISampekeyContex
    {
        TokenValidationParameters GetTokenValidationParameters(string dominio, string key);
    }
}
