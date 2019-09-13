using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sampekey.Contex;
using Sampekey.Model.Configuration.Module;

namespace Sampekey.Interface.Repository
{
    public class ModuleRepo : IModule
    {

        private readonly SampekeyDbContex context;

        public ModuleRepo(SampekeyDbContex _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<Land>> GetAllLands()
        {
            return await context.Land.ToListAsync();
        }
        public async Task<Land> FindLandById(string value)
        {
            return await context.Land.FirstOrDefaultAsync(i => i.Id == value);
        }
        public async Task<Land> AddLand(Land value)
        {
            await context.Land.AddAsync(value);
            context.SaveChanges();
            return value;
        }

        public async Task<Land> UpdateLand(Land value)
        {
            context.Update(value);
            context.SaveChanges();
            return await context.Land.FirstOrDefaultAsync(i => i.Id == value.Id);
        }
        public async Task<bool> DeleteLand(Land value)
        {
            context.Remove(value);
            await context.SaveChangesAsync();
            return true;

        }

    }
}
