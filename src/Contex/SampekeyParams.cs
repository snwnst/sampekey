using System;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Sampekey.Contex
{
    public static class SampekeyParams
    {
        public static TokenValidationParameters GetTokenValidationParameters()
        {
            return new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SAMPEKEY_SECRET_KEY"))),
                ClockSkew = TimeSpan.Zero
            };
        }
    }
}