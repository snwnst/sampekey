using Sampekey.Model.Configuration.Breakers;
using Sampekey.Model.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sampekey.Model.Administration
{
    [Table("T_PERMISSION")]
    public class Permission : Catalog
    {
        public virtual ICollection<EnviromentProjectRolePermission> EnviromentProjectRolePermissions { get; set; }
    }
}