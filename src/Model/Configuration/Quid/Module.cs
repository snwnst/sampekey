using Sampekey.Model.Configuration.Breakers;
using Sampekey.Model.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sampekey.Model.Configuration.Quid
{
    [Table("T_MODULES")]
    public class Module : PathCatalog
    {
        public virtual ICollection<ProjectModule> ProjectModules { get; set; }
    }
}