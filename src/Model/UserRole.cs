using System;
using Microsoft.AspNetCore.Identity;

namespace Sampekey.Model
{
    public class UserRole : IdentityUserRole<string>
    {
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}