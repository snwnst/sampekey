using System;
using System.Collections.Generic;

namespace Sampekey.Model
{
    public class Permission
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Description {get;set;}
        public DateTime DateRegister {get;set;} = DateTime.Now;
        public virtual ICollection<KingdomCastleRolePermission> KingdomCastleRolePermissions { get; set; }
    }
}