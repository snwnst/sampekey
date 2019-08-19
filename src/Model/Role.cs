using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Sampekey.Model
{
    public class Role : IdentityRole
    {
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<KingdomCastleRolePermission> KingdomCastleRolePermissions { get; set; }
    }
}