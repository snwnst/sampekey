using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sampekey.Contex;
using Sampekey.Model.Configuration.Breakers;
using Sampekey.Model.Configuration.Quid;

namespace Sampekey.Interface.Repository
{
    public class EsrpRepo: IEsrp
    {

        private readonly SampekeyDbContex context;

        public EsrpRepo(SampekeyDbContex _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<EnviromentProjectRolePermission>> GetAllEnviromentProjectRolePermissions()
        {
            return await context.EnviromentProjectRolePermission.ToListAsync();
        }
        public async Task<EnviromentProjectRolePermission> FindEnviromentProjectRolePermissionById(string value)
        {
            return await context.EnviromentProjectRolePermission.FirstOrDefaultAsync(i => i.Id == value);
        }
        public async Task<EnviromentProjectRolePermission> AddEnviromentProjectRolePermission(EnviromentProjectRolePermission value)
        {
            await context.EnviromentProjectRolePermission.AddAsync(value);
            context.SaveChanges();
            return value;
        }

        public async Task<EnviromentProjectRolePermission> UpdateEnviromentProjectRolePermission(EnviromentProjectRolePermission value)
        {
            context.Update(value);
            context.SaveChanges();
            return await context.EnviromentProjectRolePermission.FirstOrDefaultAsync(i => i.Id == value.Id);
        }
        public async Task<bool> DeleteEnviromentProjectRolePermission(EnviromentProjectRolePermission value)
        {
            context.Remove(value);
            await context.SaveChangesAsync();
            return true;

        }

    }
}
