using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Sampekey.Model.Identity
{
    [Table("T_USER_CLAIM")]
    public class UserClaim : IdentityUserClaim<string>
    {

    }
}