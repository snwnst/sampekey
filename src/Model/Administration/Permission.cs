using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Sampekey.Model.Configuration.Module;
using Sampekey.Model.Core;

namespace Sampekey.Model.Administration
{
    [Table("T_PERMISSION")]
    public class Permission : Catalog
    {
        public virtual ICollection<KingdomCastleRolePermission> KingdomCastleRolePermissions { get; set; }
    }
}