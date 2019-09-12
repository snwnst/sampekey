using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Sampekey.Model.Core;

namespace Sampekey.Model.Configuration.Module
{
    [Table("T_SYSTEM_MODULES")]
    public class CastleLand : PathCatalog
    {
        [Column("SystemId")]
        public string CastleId { get; set; }
        [Column("ModuleId")]
        public string LandId { get; set; }

        public virtual Castle Castle { get; set; }
        public virtual Land Land { get; set; }
    }
}