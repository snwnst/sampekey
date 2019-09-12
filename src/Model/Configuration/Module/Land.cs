using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Sampekey.Model.Core;

namespace Sampekey.Model.Configuration.Module
{
    [Table("T_MODULES")]
    public class Land : PathCatalog
    {
        public virtual ICollection<CastleLand> CastleLands { get; set; }
    }
}