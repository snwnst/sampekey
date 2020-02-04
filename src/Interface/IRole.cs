using Sampekey.Model.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sampekey.Interface
{
    public interface IRole
    {
        Task<IEnumerable<Role>> GetAllRoles();
        Task<Role> FindRoleById(string value);
        Task<Role> AddRole(Role value);
        Task<Role> UpdateRole(Role value);
        Task<bool> DeleteRole(Role value);
    }
}

