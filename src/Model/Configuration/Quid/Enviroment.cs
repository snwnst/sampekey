using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Sampekey.Model.Configuration.Breakers;
using Sampekey.Model.Core;

namespace Sampekey.Model.Configuration.Quid
{
    [Table("T_ENVIROMENT", Schema = "dbo")]
    public class Enviroment: Catalog
    {
        public virtual ICollection<EnviromentProjectRolePermission> EnviromentProjectRolePermissions { get; set; }
    }
}