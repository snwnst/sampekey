using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Sampekey.Model
{
    public class Role : IdentityRole
    {
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<RoleClaim> RoleClaims { get; set; }
    }
}