using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Sampekey.Contex;
using Microsoft.AspNetCore.Identity;
using Sampekey.Model.Identity;

namespace Sampekey.Interface
{
    public interface IAccount
    {
        Task<Boolean> Login(SampekeyUserAccountRequest userAccountRequest);
        Task UpdateForcePaswordAsync(SampekeyUserAccountRequest userAccountRequest);
        HashSet<string> GetUsersWithActiveDirectory(SampekeyUserAccountRequest userAccountRequest);
        Task<IdentityResult> CreateUser(SampekeyUserAccountRequest userAccountRequest);
        Task<IdentityResult> AddDefaultRoleToUser(User user);
    }
}

