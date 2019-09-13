using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sampekey.Contex;
using Sampekey.Model.Configuration.Module;

namespace Sampekey.Interface.Repository
{
    public class EsrpRepo: IEsrp
    {

        private readonly SampekeyDbContex context;

        public EsrpRepo(SampekeyDbContex _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<KingdomCastleRolePermission>> GetAllKingdomCastleRolePermissions()
        {
            return await context.KingdomCastleRolePermission.ToListAsync();
        }
        public async Task<KingdomCastleRolePermission> FindKingdomCastleRolePermissionById(string value)
        {
            return await context.KingdomCastleRolePermission.FirstOrDefaultAsync(i => i.Id == value);
        }
        public async Task<KingdomCastleRolePermission> AddKingdomCastleRolePermission(KingdomCastleRolePermission value)
        {
            await context.KingdomCastleRolePermission.AddAsync(value);
            context.SaveChanges();
            return value;
        }

        public async Task<KingdomCastleRolePermission> UpdateKingdomCastleRolePermission(KingdomCastleRolePermission value)
        {
            context.Update(value);
            context.SaveChanges();
            return await context.KingdomCastleRolePermission.FirstOrDefaultAsync(i => i.Id == value.Id);
        }
        public async Task<bool> DeleteKingdomCastleRolePermission(KingdomCastleRolePermission value)
        {
            context.Remove(value);
            await context.SaveChangesAsync();
            return true;

        }

    }
}
