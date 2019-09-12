using System;
using System.ComponentModel.DataAnnotations.Schema;
using Sampekey.Model.Administration;
using Sampekey.Model.Core;
using Sampekey.Model.Identity;

namespace Sampekey.Model.Configuration.Module
{
    [Table("T_ENVIROMENT_SYSTEM_ROLE_PERMISSION")]
    public class KingdomCastleRolePermission: Default
    {
        [Column("EnviromentId")]
        public string KingdomId { get; set;}
        [Column("SystemId")]
        public string CastleId { get; set; }
        public string RoleId { get; set;}
        public string PermissionId { get; set; }
        public virtual Kingdom Kingdom { get; set; }
        public virtual Castle Castle { get; set; }
        public virtual Role Role { get; set; }
        public virtual Permission Permission { get; set; }  

    }
}