using System.Collections.Generic;
using System.Threading.Tasks;
using Sampekey.Model.Configuration.Module;

namespace Sampekey.Interface
{
    public interface IEsrp
    {
        Task<IEnumerable<KingdomCastleRolePermission>> GetAllKingdomCastleRolePermissions();
        Task<KingdomCastleRolePermission> FindKingdomCastleRolePermissionById(string value);
        Task<KingdomCastleRolePermission> AddKingdomCastleRolePermission(KingdomCastleRolePermission value);
        Task<KingdomCastleRolePermission> UpdateKingdomCastleRolePermission(KingdomCastleRolePermission value);
        Task<bool> DeleteKingdomCastleRolePermission(KingdomCastleRolePermission value);
        
    }
}
