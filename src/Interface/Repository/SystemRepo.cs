using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sampekey.Contex;
using Sampekey.Model.Configuration.Module;

namespace Sampekey.Interface.Repository
{
    public class SystemRepo : ISystem
    {

        private readonly SampekeyDbContex context;

        public SystemRepo(SampekeyDbContex _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<Castle>> GetAllCastles()
        {
            return await context.Castle.ToListAsync();
        }
        public async Task<Castle> FindCastleById(string value)
        {
            return await context.Castle.FirstOrDefaultAsync(i => i.Id == value);
        }
        public async Task<Castle> AddCastle(Castle value)
        {
            await context.Castle.AddAsync(value);
            context.SaveChanges();
            return value;
        }

        public async Task<Castle> UpdateCastle(Castle value)
        {
            context.Update(value);
            context.SaveChanges();
            return await context.Castle.FirstOrDefaultAsync(i => i.Id == value.Id);
        }
        public async Task<bool> DeleteCastle(Castle value)
        {
            context.Remove(value);
            await context.SaveChangesAsync();
            return true;

        }

    }
}
