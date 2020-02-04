using Microsoft.AspNetCore.Identity;
using Sampekey.Contex;
using Sampekey.Model.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

