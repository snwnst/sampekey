using System;
using Microsoft.AspNetCore.Identity;

namespace Sampekey.Contex
{
    public partial class SampekeyUserAccountRequest : IdentityUser
    {
        public string Password { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int ExpirationHours { get; set; } = 1;
        public string NewPassword { get; set; }
    }
}