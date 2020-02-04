using Microsoft.EntityFrameworkCore;
using Sampekey.Contex;
using Sampekey.Model.Configuration.Quid;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sampekey.Interface.Repository
{
    public class EnviromentRepo : IEnviroment
    {

        private readonly SampekeyDbContex context;

        public EnviromentRepo(SampekeyDbContex _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<Enviroment>> GetAllEnviroments()
        {
            return await context.Enviroment.ToListAsync();
        }
        public async Task<Enviroment> FindEnviromentById(string value)
        {
            return await context.Enviroment.FirstOrDefaultAsync(i => i.Id == value);
        }
        public async Task<Enviroment> AddEnviroment(Enviroment value)
        {
            await context.Enviroment.AddAsync(value);
            context.SaveChanges();
            return value;
        }

        public async Task<Enviroment> UpdateEnviroment(Enviroment value)
        {
            context.Update(value);
            context.SaveChanges();
            return await context.Enviroment.FirstOrDefaultAsync(i => i.Id == value.Id);
        }
        public async Task<bool> DeleteEnviroment(Enviroment value)
        {
            context.Remove(value);
            await context.SaveChangesAsync();
            return true;

        }

    }
}
