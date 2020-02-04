using Microsoft.EntityFrameworkCore;
using Sampekey.Contex;
using Sampekey.Model.Configuration.Quid;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sampekey.Interface.Repository
{
    public class ModuleRepo : IModule
    {

        private readonly SampekeyDbContex context;

        public ModuleRepo(SampekeyDbContex _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<Module>> GetAllModules()
        {
            return await context.Module.ToListAsync();
        }
        public async Task<Module> FindModuleById(string value)
        {
            return await context.Module.FirstOrDefaultAsync(i => i.Id == value);
        }
        public async Task<Module> AddModule(Module value)
        {
            await context.Module.AddAsync(value);
            context.SaveChanges();
            return value;
        }

        public async Task<Module> UpdateModule(Module value)
        {
            context.Update(value);
            context.SaveChanges();
            return await context.Module.FirstOrDefaultAsync(i => i.Id == value.Id);
        }
        public async Task<bool> DeleteModule(Module value)
        {
            context.Remove(value);
            await context.SaveChangesAsync();
            return true;

        }

    }
}
