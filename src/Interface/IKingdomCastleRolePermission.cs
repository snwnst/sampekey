using System.Collections.Generic;
using System.Threading.Tasks;
using Sampekey.Model.Configuration.Module;

namespace Sampekey.Interface
{
    public interface IKingdomCastleRolePermission
    {
        Task<IEnumerable<KingdomCastleRolePermission>> GetAllKingdomCastleRolePermissions();
        Task<KingdomCastleRolePermission> FindKingdomCastleRolePermissionById(KingdomCastleRolePermission value);
        Task<KingdomCastleRolePermission> AddKingdomCastleRolePermission(KingdomCastleRolePermission value);
        Task<KingdomCastleRolePermission> UpdateKingdomCastleRolePermission(KingdomCastleRolePermission value);
        Task<bool> DeleteKingdomCastleRolePermission(KingdomCastleRolePermission value);
        
    }
}
