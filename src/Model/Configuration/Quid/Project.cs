using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Sampekey.Model.Configuration.Breakers;
using Sampekey.Model.Core;

namespace Sampekey.Model.Configuration.Quid
{
    [Table("T_SYSTEM", Schema = "dbo")]
    public class Project : PathCatalog
    {
        public virtual ICollection<EnviromentProjectRolePermission> EnviromentProjectRolePermissions { get; set; }
        public virtual ICollection<ProjectModule> ProjectModules { get; set; }
        
    }
}