using Sampekey.Model.Configuration.Quid;
using Sampekey.Model.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sampekey.Model.Configuration.Breakers
{
    [Table("T_SYSTEM_MODULES")]
    public class ProjectModule : Default
    {
        public string ProjectId { get; set; }
        public string ModuleId { get; set; }

        public virtual Project Project { get; set; }
        public virtual Module Module { get; set; }
    }
}