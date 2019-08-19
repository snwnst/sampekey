
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Sampekey.Model
{
    public class User : IdentityUser
    {
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}