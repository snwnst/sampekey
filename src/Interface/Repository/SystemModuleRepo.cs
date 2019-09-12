using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sampekey.Contex;
using Sampekey.Model.Configuration.Module;

namespace Sampekey.Interface.Repository
{
    public class SystemModuleRepo : ISystemModule
    {

        private readonly SampekeyDbContex context;

        public SystemModuleRepo(SampekeyDbContex _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<CastleLand>> GetAllCastleLands()
        {
            return await context.CastleLand.ToListAsync();
        }
        public async Task<CastleLand> FindCastleLandById(CastleLand value)
        {
            return await context.CastleLand.FirstOrDefaultAsync(i => i.Id == value.Id);
        }
        public async Task<CastleLand> AddCastleLand(CastleLand value)
        {
            await context.CastleLand.AddAsync(value);
            context.SaveChanges();
            return value;
        }

        public async Task<CastleLand> UpdateCastleLand(CastleLand value)
        {
            context.Update(value);
            context.SaveChanges();
            return await context.CastleLand.FirstOrDefaultAsync(i => i.Id == value.Id);
        }
        public async Task<bool> DeleteCastleLand(CastleLand value)
        {
            context.Remove(value);
            await context.SaveChangesAsync();
            return true;

        }

    }
}
