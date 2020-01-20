using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Sampekey.Model.Configuration.Breakers;
using Sampekey.Model.Configuration.Quid;
using Sampekey.Model.Core;

namespace Sampekey.Model.Administration
{
    [Table("T_PERMISSION", Schema = "sake")]
    public class Permission : Catalog
    {
        public virtual ICollection<EnviromentProjectRolePermission> EnviromentProjectRolePermissions { get; set; }
    }
}