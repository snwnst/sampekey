
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Sampekey.Model
{
    public class User: IdentityUser
    {
        public DateTime DateRegister { get; set; }
        public string IdStatus { get; set; }
        public Status Status { get; set; }
        public ICollection<UserToken> UserTokens { get; set; }
        public ICollection<UserClaim> UserClaims { get; internal set; }
        public ICollection<UserLogin> UserLogins { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}