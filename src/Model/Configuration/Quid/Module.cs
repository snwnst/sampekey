using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Sampekey.Model.Configuration.Breakers;
using Sampekey.Model.Core;

namespace Sampekey.Model.Configuration.Quid
{
    [Table("T_MODULES", Schema = "dbo")]
    public class Module : PathCatalog
    {
        public virtual ICollection<ProjectModule> ProjectModules { get; set; }
    }
}