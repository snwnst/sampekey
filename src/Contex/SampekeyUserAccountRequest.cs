using System;
using Microsoft.AspNetCore.Identity;

namespace Sampekey.Contex
{
    public partial class SampekeyUserAccountRequest: IdentityUser
    {
        public string Password { get; set; }
    }
}