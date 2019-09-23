using System;
using Novell.Directory.Ldap;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Collections.Generic;
using Sampekey.Contex;
using Sampekey.Model.Identity;

namespace Sampekey.Interface.Repository
{
    public class AccountRepo : IAccount
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountRepo(

            UserManager<User> _userManager,
            SignInManager<User> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }

        public async Task<SignInResult> LoginWithActiveDirectory(SampekeyUserAccountRequest userAccountRequest)
        {

            using (var connection = new LdapConnection { SecureSocketLayer = false })
            {
                connection.Connect(Environment.GetEnvironmentVariable("AD_DDOMAIN"), int.Parse(Environment.GetEnvironmentVariable("AD_PORT")));
                connection.Bind($"{userAccountRequest.UserName}@{Environment.GetEnvironmentVariable("AD_DDOMAIN")}", userAccountRequest.Password);
                var aux = connection.Bound;
                await UpdateForcePaswordAsync(userAccountRequest);
                return await signInManager.PasswordSignInAsync(userAccountRequest.UserName, userAccountRequest.Password, isPersistent: false, lockoutOnFailure: false);
            }
        }

        public Task<SignInResult> LoginWithSampeKey(SampekeyUserAccountRequest userAccountRequest)
        {
            return signInManager.PasswordSignInAsync(userAccountRequest.UserName, userAccountRequest.Password, isPersistent: false, lockoutOnFailure: false);
        }

        public HashSet<string> GetUsersWithActiveDirectory(SampekeyUserAccountRequest userAccountRequest)
        {
            var users = new HashSet<string>();
            try
            {
                using (var connection = new LdapConnection { SecureSocketLayer = false })
                {
                    connection.Connect(Environment.GetEnvironmentVariable("AD_DDOMAIN"), int.Parse(Environment.GetEnvironmentVariable("AD_PORT")));
                    connection.Bind($"{userAccountRequest.UserName}@{Environment.GetEnvironmentVariable("AD_DDOMAIN")}", userAccountRequest.Password);
                    LdapSearchResults searchResults = connection.Search(
                    Environment.GetEnvironmentVariable("BIND_DN"),
                    LdapConnection.SCOPE_SUB,
                    Environment.GetEnvironmentVariable("LDAP_FILTER"),
                    null,
                    false
                    );
                    while (searchResults.hasMore())
                    {
                        LdapEntry nextEntry = null;
                        nextEntry = searchResults.next();
                        nextEntry.getAttributeSet();
                        var attr = nextEntry.getAttribute("mail");
                        if (attr == null)
                        {
                            users.Add(nextEntry.getAttribute("distinguishedName").StringValue);
                        }
                        else
                        {
                            users.Add(nextEntry.getAttribute("mail").StringValue);
                        }
                    }
                    return users;
                }
            }
            catch
            {
                return users;
            }
        }

        public async Task UpdateForcePaswordAsync(SampekeyUserAccountRequest userAccountRequest)
        {
            await userManager.RemovePasswordAsync(userAccountRequest);
            await userManager.AddPasswordAsync(userAccountRequest, userAccountRequest.Password);
        }

        public Task<IdentityResult> CreateUser(SampekeyUserAccountRequest userAccountRequest)
        {
            return userManager.CreateAsync(userAccountRequest, userAccountRequest.Password);
        }

        public Task<IdentityResult> AddDefaultRoleToUser(User user)
        {
            return userManager.AddToRoleAsync(user, "default");
        }

    }
}