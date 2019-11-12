
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Sampekey.Model.Identity
{
    [Table("T_USER")]
    public class User : IdentityUser
    {
        [Column(TypeName="timestamp")]
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public Boolean Active { get; set; } = true;
        public Boolean userFromActiveDirectory { get; set; } = false;
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}