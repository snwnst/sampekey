using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Sampekey.Model.Identity

{
    [Table("T_ROLE_CLAIM")]
    public class RoleClaim : IdentityRoleClaim<string>
    {

    }
}