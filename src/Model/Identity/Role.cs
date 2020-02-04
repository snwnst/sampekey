using Microsoft.AspNetCore.Identity;
using Sampekey.Model.Configuration.Breakers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sampekey.Model.Identity
{
    [Table("T_ROLE")]
    public class Role : IdentityRole
    {
        public virtual ICollection<EnviromentProjectRolePermission> EnviromentProjectRolePermissions { get; set; }
    }
}