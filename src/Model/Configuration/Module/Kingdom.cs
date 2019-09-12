using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Sampekey.Model.Core;

namespace Sampekey.Model.Configuration.Module
{
    [Table("T_ENVIROMENT")]
    public class Kingdom: Catalog
    {
        public virtual ICollection<KingdomCastleRolePermission> KingdomCastleRolePermissions { get; set; }
    }
}