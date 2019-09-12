using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sampekey.Model.Core
{
    public class PathCatalog: Catalog
    {
        public string Path { get; set; }
        public string Icon { get; set; }
        public string Class { get; set; }

    }
}