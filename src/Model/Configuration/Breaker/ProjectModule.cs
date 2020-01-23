using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Sampekey.Model.Configuration.Quid;
using Sampekey.Model.Core;

namespace Sampekey.Model.Configuration.Breakers
{
    [Table("T_SYSTEM_MODULES", Schema = "dbo")]
    public class ProjectModule : Default
    {
        public string ProjectId { get; set; }
        public string ModuleId { get; set; }

        public virtual Project Project { get; set; }
        public virtual Module Module { get; set; }
    }
}