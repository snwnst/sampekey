using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sampekey.Contex;
using Sampekey.Model.Configuration.Module;

namespace Sampekey.Interface.Repository
{
    public class EnviromentRepo : IEnviroment
    {

        private readonly SampekeyDbContex context;

        public EnviromentRepo(SampekeyDbContex _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<Kingdom>> GetAllKingdoms()
        {
            return await context.Kingdom.ToListAsync();
        }
        public async Task<Kingdom> FindKingdomById(Kingdom value)
        {
            return await context.Kingdom.FirstOrDefaultAsync(i => i.Id == value.Id);
        }
        public async Task<Kingdom> AddKingdom(Kingdom value)
        {
            await context.Kingdom.AddAsync(value);
            context.SaveChanges();
            return value;
        }

        public async Task<Kingdom> UpdateKingdom(Kingdom value)
        {
            context.Update(value);
            context.SaveChanges();
            return await context.Kingdom.FirstOrDefaultAsync(i => i.Id == value.Id);
        }
        public async Task<bool> DeleteKingdom(Kingdom value)
        {
            context.Remove(value);
            await context.SaveChangesAsync();
            return true;

        }

    }
}
