using System;

namespace sampekey.classes
{
    public class SampekeyContex: ISampekeyContex
    {
        public JwtSecurityToken GetTokenValidationParameters(string dominio)
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
