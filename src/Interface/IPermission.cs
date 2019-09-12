using System.Collections.Generic;
using System.Threading.Tasks;
using Sampekey.Model.Administration;

namespace Sampekey.Interface
{
    public interface IPermission
    {
        Task<IEnumerable<Permission>> GetAllPermissions();
        Task<Permission> FindPermissionById(Permission value);
        Task<Permission> AddPermission(Permission value);
        Task<Permission> UpdatePermission(Permission value);
        Task<bool> DeletePermission(Permission value);

    }
}
