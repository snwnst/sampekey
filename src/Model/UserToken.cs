using System;
using Microsoft.AspNetCore.Identity;

namespace Sampekey.Model
{
    public class UserToken : IdentityUserToken<string>
    {
        public DateTime ExpirationDate { get; set; }
        public User User { get; set; }
    }
}