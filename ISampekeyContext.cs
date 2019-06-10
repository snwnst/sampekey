using System;

namespace sampekey
{
    public interface ISampekeyContex
    {
        JwtSecurityToken GetTokenValidationParameters(string dominio);
    }
}
