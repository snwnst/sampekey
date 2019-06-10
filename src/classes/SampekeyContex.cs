using System;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using sampekey.interfaces;

namespace sampekey.classes
{
    public class SampekeyContex: ISampekeyContex
    {
        public TokenValidationParameters GetTokenValidationParameters(string dominio, string Key)
        {
            return new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "Dominio",
                ValidAudience = dominio,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key)),
                ClockSkew = TimeSpan.Zero
            };
        }
    }
}
