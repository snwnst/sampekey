using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Sampekey.Model.Configuration.Module;
using Sampekey.Model.Core;

namespace Sampekey.Model.Administration
{
    [Table("T_PERMISSION")]
    public class Permission : Default
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<KingdomCastleRolePermission> KingdomCastleRolePermissions { get; set; }
    }
}