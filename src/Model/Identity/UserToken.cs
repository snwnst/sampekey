using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sampekey.Model.Identity
{
    [Table("T_USER_TOKEN")]
    public class UserToken : IdentityUserToken<string>
    {

    }
}