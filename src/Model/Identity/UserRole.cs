using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Sampekey.Model.Identity
{
    [Table("T_USER_ROLE")]
    public class UserRole : IdentityUserRole<string>
    {
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}