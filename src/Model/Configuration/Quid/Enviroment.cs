using Sampekey.Model.Configuration.Breakers;
using Sampekey.Model.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sampekey.Model.Configuration.Quid
{
    [Table("T_ENVIROMENT")]
    public class Enviroment : Catalog
    {
        public virtual ICollection<EnviromentProjectRolePermission> EnviromentProjectRolePermissions { get; set; }
    }
}