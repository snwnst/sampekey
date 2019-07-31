using System;
using Microsoft.AspNetCore.Identity;

namespace Sampekey.Model
{
    public class RoleClaim : IdentityRoleClaim<string>
    {
        public Role Role { get; set; }
    }
}