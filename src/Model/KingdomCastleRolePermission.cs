using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sampekey.Model
{
    public class KingdomCastleRolePermission
    {
        [Column("EnviromentId")]
        public string KingdomId { get; set;}
        [Column("SystemId")]
        public string CastleId { get; set; }
        public string RoleId { get; set;}
        public string PermissionId { get; set; }
        public Boolean Value { get; set; } = false;
        public virtual Kingdom Kingdom { get; set; }
        public virtual Castle Castle { get; set; }
        public virtual Role Role { get; set; }
        public virtual Permission Permission { get; set; }  

    }
}