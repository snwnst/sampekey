using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Sampekey.Contex;
using Microsoft.AspNetCore.Identity;

namespace Sampekey.Interface
{
    public interface IAccount
    {
        Boolean LoginWithActiveDirectory(SampekeyUserAccountRequest userAccountRequest);
        Task<SignInResult> LoginWithSampeKey(SampekeyUserAccountRequest userAccountRequest);
        Task UpdateForcePaswordAsync(SampekeyUserAccountRequest userAccountRequest);
        HashSet<string> GetUsersWithActiveDirectory(SampekeyUserAccountRequest userAccountRequest);
    }
}

