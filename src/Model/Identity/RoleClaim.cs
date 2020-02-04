using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sampekey.Model.Identity

{
    [Table("T_ROLE_CLAIM")]
    public class RoleClaim : IdentityRoleClaim<string>
    {

    }
}