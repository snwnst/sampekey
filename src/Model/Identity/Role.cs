using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Sampekey.Model.Configuration.Module;

namespace Sampekey.Model.Identity
{
    [Table("T_ROLE")]
    public class Role : IdentityRole
    {
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<KingdomCastleRolePermission> KingdomCastleRolePermissions { get; set; }
    }
}