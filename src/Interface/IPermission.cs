using Sampekey.Model.Administration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sampekey.Interface
{
    public interface IPermission
    {
        Task<IEnumerable<Permission>> GetAllPermissions();
        Task<Permission> FindPermissionById(string value);
        Task<Permission> AddPermission(Permission value);
        Task<Permission> UpdatePermission(Permission value);
        Task<bool> DeletePermission(Permission value);

    }
}
