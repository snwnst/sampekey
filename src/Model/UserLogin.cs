using System;
using Microsoft.AspNetCore.Identity;

namespace Sampekey.Model
{
    public class UserLogin : IdentityUserLogin<string>
    {
        public User User { get; set; }
    }
}