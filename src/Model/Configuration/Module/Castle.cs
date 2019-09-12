using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Sampekey.Model.Core;

namespace Sampekey.Model.Configuration.Module
{
    [Table("T_SYSTEM")]
    public class Castle : PathCatalog
    {
        public virtual ICollection<KingdomCastleRolePermission> KingdomCastleRolePermissions { get; set; }
        public virtual ICollection<CastleLand> CastleLands { get; set; }
        
    }
}