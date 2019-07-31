using System;
using System.Collections.Generic;

namespace Sampekey.Model
{
    public class Status
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Key { get; set; }
        public string Description { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
