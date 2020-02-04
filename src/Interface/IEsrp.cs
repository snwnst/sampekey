using Sampekey.Model.Configuration.Breakers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sampekey.Interface
{
    public interface IEsrp
    {
        Task<IEnumerable<EnviromentProjectRolePermission>> GetAllEnviromentProjectRolePermissions();
        Task<EnviromentProjectRolePermission> FindEnviromentProjectRolePermissionById(string value);
        Task<EnviromentProjectRolePermission> AddEnviromentProjectRolePermission(EnviromentProjectRolePermission value);
        Task<EnviromentProjectRolePermission> UpdateEnviromentProjectRolePermission(EnviromentProjectRolePermission value);
        Task<bool> DeleteEnviromentProjectRolePermission(EnviromentProjectRolePermission value);

    }
}
