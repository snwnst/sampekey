using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sampekey.Contex;
using Sampekey.Model.Configuration.Breakers;
using Sampekey.Model.Configuration.Quid;

namespace Sampekey.Interface.Repository
{
    public class SystemModuleRepo : ISystemModule
    {

        private readonly SampekeyDbContex context;

        public SystemModuleRepo(SampekeyDbContex _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<ProjectModule>> GetAllProjectModules()
        {
            return await context.ProjectModule.ToListAsync();
        }
        public async Task<ProjectModule> FindProjectModuleById(string value)
        {
            return await context.ProjectModule.FirstOrDefaultAsync(i => i.Id == value);
        }
        public async Task<ProjectModule> AddProjectModule(ProjectModule value)
        {
            await context.ProjectModule.AddAsync(value);
            context.SaveChanges();
            return value;
        }

        public async Task<ProjectModule> UpdateProjectModule(ProjectModule value)
        {
            context.Update(value);
            context.SaveChanges();
            return await context.ProjectModule.FirstOrDefaultAsync(i => i.Id == value.Id);
        }
        public async Task<bool> DeleteProjectModule(ProjectModule value)
        {
            context.Remove(value);
            await context.SaveChangesAsync();
            return true;

        }

    }
}
