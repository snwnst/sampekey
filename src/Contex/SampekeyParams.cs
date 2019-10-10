using System;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;


namespace Sampekey.Contex
{
    public static class SampekeyParams
    {
        static public string Key { get => Environment.GetEnvironmentVariable("SAMPEKEY_SECRET_KEY"); }
        static public string Dominio { get => Environment.GetEnvironmentVariable("AD_DDOMAIN"); }
        static public int Expire { get => int.Parse(Environment.GetEnvironmentVariable("MAX_EXPIRATION_HOURS")); }

        public static TokenValidationParameters GetTokenValidationParameters()
        {
            return new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = Dominio,
                ValidAudience = Dominio,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key)),
                ClockSkew = TimeSpan.Zero
            };
        }

        public static string CreateToken(SampekeyUserAccountRequest model)
        {
            return new JwtSecurityTokenHandler().WriteToken(GetJwtSecurityToken(model));
        }

        public static JwtSecurityToken GetJwtSecurityToken(SampekeyUserAccountRequest model)
        {
            return new JwtSecurityToken(
                issuer: Dominio,
                audience: Dominio,
                claims: new[]
                {
                    new Claim(JwtRegisteredClaimNames.UniqueName, model.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                },
                expires: DateTime.UtcNow.AddHours(Expire),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key)),
                    SecurityAlgorithms.HmacSha256
                )
            );
        }

    }
}