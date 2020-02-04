using Microsoft.EntityFrameworkCore;
using Sampekey.Contex;
using Sampekey.Model.Configuration.Quid;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sampekey.Interface.Repository
{
    public class SystemRepo : ISystem
    {

        private readonly SampekeyDbContex context;

        public SystemRepo(SampekeyDbContex _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<Project>> GetAllProjects()
        {
            return await context.Project.ToListAsync();
        }
        public async Task<Project> FindProjectById(string value)
        {
            return await context.Project.FirstOrDefaultAsync(i => i.Id == value);
        }
        public async Task<Project> AddProject(Project value)
        {
            await context.Project.AddAsync(value);
            context.SaveChanges();
            return value;
        }

        public async Task<Project> UpdateProject(Project value)
        {
            context.Update(value);
            context.SaveChanges();
            return await context.Project.FirstOrDefaultAsync(i => i.Id == value.Id);
        }
        public async Task<bool> DeleteProject(Project value)
        {
            context.Remove(value);
            await context.SaveChangesAsync();
            return true;

        }

    }
}
