using System;
using System.ComponentModel.DataAnnotations.Schema;
using Sampekey.Model.Administration;
using Sampekey.Model.Configuration.Quid;
using Sampekey.Model.Core;
using Sampekey.Model.Identity;

namespace Sampekey.Model.Configuration.Breakers
{
    [Table("T_ENVIROMENT_SYSTEM_ROLE_PERMISSION", Schema = "dbo")]
    public class EnviromentProjectRolePermission: Default
    {
        public string EnviromentId { get; set;}
        public string ProjectId { get; set; }
        public string RoleId { get; set;}
        public string PermissionId { get; set; }
        public virtual Enviroment Enviroment { get; set; }
        public virtual Project Project { get; set; }
        public virtual Role Role { get; set; }
        public virtual Permission Permission { get; set; }  

    }
}