using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sampekey.Model.Configuration.Module
{
    [Table("T_SYSTEM")]
    public class Castle
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<KingdomCastleRolePermission> KingdomCastleRolePermissions { get; set; }
    }
}