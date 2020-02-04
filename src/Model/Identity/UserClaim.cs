using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sampekey.Model.Identity
{
    [Table("T_USER_CLAIM")]
    public class UserClaim : IdentityUserClaim<string>
    {

    }
}