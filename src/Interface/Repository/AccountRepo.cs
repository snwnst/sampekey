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
        private readonly SignInManager<User> signInManager ;

        public AccountRepo(
            UserManager<User> _userManager,
            SignInManager<User> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }

        public async Task<Boolean> Login(SampekeyUserAccountRequest userAccountRequest)
        {
            try
            {
                using (var connection = new LdapConnection { SecureSocketLayer = false })
                {
                    var _domain = Environment.GetEnvironmentVariable("AD_DDOMAIN");
                    var _domainServer = Environment.GetEnvironmentVariable("AD_DDOMAIN_SSERVER");
                    var _port = Environment.GetEnvironmentVariable("AD_PORT");
                    connection.Connect(_domainServer, int.Parse(_port));
                    connection.Bind($"{userAccountRequest.UserName}@{_domain}", userAccountRequest.Password);
                    var aux = connection.Bound;
                    return true;
                }
            }
            catch (System.Exception)
            {
                if((await signInManager.PasswordSignInAsync(userAccountRequest.UserName, userAccountRequest.Password, isPersistent: false, lockoutOnFailure: false)).Succeeded)
                    return true;
                else 
                    return false;
            }
        }

        public HashSet<string> GetUsersWithActiveDirectory(SampekeyUserAccountRequest userAccountRequest)
        {
            var users = new HashSet<string>();
            try
            {
                using (var connection = new LdapConnection { SecureSocketLayer = false })
                {
                    var _domain = Environment.GetEnvironmentVariable("AD_DDOMAIN");
                    var _domainServer = Environment.GetEnvironmentVariable("AD_DDOMAIN_SSERVER");
                    var _port = Environment.GetEnvironmentVariable("AD_PORT");

                    connection.Connect(_domainServer, int.Parse(_port));
                    connection.Bind($"{userAccountRequest.UserName}@{_domain}", userAccountRequest.Password);
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
            var user = await userManager.FindByEmailAsync(userAccountRequest.Email);
            var token = await userManager.GeneratePasswordResetTokenAsync(user);
            await userManager.ResetPasswordAsync(user, token, userAccountRequest.Password);
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