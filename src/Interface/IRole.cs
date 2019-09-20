using System.Threading.Tasks;
using System.Collections.Generic;
using Sampekey.Model.Identity;

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

