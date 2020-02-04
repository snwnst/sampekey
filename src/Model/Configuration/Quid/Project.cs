using Sampekey.Model.Configuration.Breakers;
using Sampekey.Model.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sampekey.Model.Configuration.Quid
{
    [Table("T_SYSTEM")]
    public class Project : PathCatalog
    {
        public virtual ICollection<EnviromentProjectRolePermission> EnviromentProjectRolePermissions { get; set; }
        public virtual ICollection<ProjectModule> ProjectModules { get; set; }

    }
}